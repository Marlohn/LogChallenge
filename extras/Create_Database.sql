-- ----------------------------
-- Table structure for Log
-- ----------------------------
DROP TABLE IF EXISTS "public"."Log";
CREATE TABLE "public"."Log" (
  "Id" uuid NOT NULL DEFAULT uuid_generate_v4(),
  "Host" varchar(20) COLLATE "pg_catalog"."default" NOT NULL,
  "Identity" varchar(50) COLLATE "pg_catalog"."default",
  "User" varchar(50) COLLATE "pg_catalog"."default",
  "DateTime" timestamptz(6) NOT NULL,
  "Request" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "StatusCode" int2 NOT NULL,
  "Size" int4,
  "Referer" varchar(255) COLLATE "pg_catalog"."default",
  "UserAgent" varchar(255) COLLATE "pg_catalog"."default",
  "RegDate" timestamp(6) NOT NULL,
  "UpdateDate" timestamp(6) NOT NULL
)
;

-- ----------------------------
-- Uniques structure for table Log
-- ----------------------------
ALTER TABLE "public"."Log" ADD CONSTRAINT "unique_id" UNIQUE ("Id");

-- ----------------------------
-- Primary Key structure for table Log
-- ----------------------------
ALTER TABLE "public"."Log" ADD CONSTRAINT "Log_pkey" PRIMARY KEY ("Id");
