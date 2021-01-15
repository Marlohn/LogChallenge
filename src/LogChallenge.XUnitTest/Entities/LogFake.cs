using Bogus;
using LogChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogChallenge.XUnitTest.Entities
{
    public class LogFake
    {
        static string[] HTTP_VERBS = new[] { "POST", "GET", "PUT", "PATCH", "DELETE" };
        static string[] HTTP_VERSIONS = new[] { "HTTP/1.0", "HTTP/1.1", "HTTP/2.0" };

        public Log Generate()
        {
            return new Faker<Log>()
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Host, f => f.Internet.Ip())
                .RuleFor(u => u.Identity, f => f.Internet.UserNameUnicode())
                .RuleFor(u => u.User, f => f.Internet.UserName())
                .RuleFor(u => u.DateTime, f => f.Date.Past())
                .RuleFor(u => u.Request, f => f.PickRandom(HTTP_VERBS) + " " + f.Internet.UrlWithPath() + " " + f.PickRandom(HTTP_VERSIONS))
                .RuleFor(u => u.StatusCode, f => f.Random.Number(100, 999))
                .RuleFor(o => o.Size, f => f.Random.Number(0, 100000))
                .RuleFor(u => u.Referer, f => f.Internet.UrlWithPath())
                .RuleFor(u => u.UserAgent, f => f.Internet.UserAgent())
                .RuleFor(u => u.RegDate, f => f.Date.Past())
                .RuleFor(u => u.UpdateDate, f => f.Date.Recent(0))
                .Generate();
        }

        public List<Log> Generate(int count) 
        {
            var returnList = new List<Log>();
            for (int i = 0; i < count; i++)
            {
                returnList.Add(Generate());
            }
            return returnList;
        }

        public List<Log> Generate(int count, int errors)
        {
            var returnList = new List<Log>();
            if (count < errors) return returnList;

            for (int i = 0; i < count; i++)
            {                
                returnList.Add(Generate());
            }

            Random rnd = new Random();
            foreach (var p in returnList.OrderBy(p => rnd.Next()).Take(errors).ToList()) 
            {
                p.Host = "";
            }

            return returnList;
        }

    }
}
