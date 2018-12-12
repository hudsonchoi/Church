IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'course_code'
)
BEGIN
	ALTER TABLE courses 
    ADD course_code VARCHAR(20) NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'year_no'
)
BEGIN
	ALTER TABLE courses 
    ADD year_no int NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'semester_no'
)
BEGIN
	ALTER TABLE courses 
    ADD semester_no int NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'teacher_name'
)
BEGIN
	ALTER TABLE courses 
    ADD teacher_name nvarchar(80) NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'start_date'
)
BEGIN
	ALTER TABLE courses 
    ADD start_date date NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'day_of_week'
)
BEGIN
	ALTER TABLE courses 
    ADD day_of_week int NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'duration_hour'
)
BEGIN
	ALTER TABLE courses 
    ADD duration_hour decimal(5,1) NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'lecture_period_week'
)
BEGIN
	ALTER TABLE courses 
    ADD lecture_period_week int NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'end_date'
)
BEGIN
	ALTER TABLE courses 
    ADD end_date date NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'credit'
)
BEGIN
	ALTER TABLE courses 
    ADD credit decimal(5,1) NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'difficulty'
)
BEGIN
	ALTER TABLE courses 
    ADD difficulty char(1) NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'prerequisite_course_id'
)
BEGIN
	ALTER TABLE courses 
    ADD prerequisite_course_id int NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'active_yn'
)
BEGIN
	ALTER TABLE courses 
    ADD active_yn char(1) NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'create_date'
)
BEGIN
	ALTER TABLE courses 
    ADD create_date datetime NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'create_by'
)
BEGIN
	ALTER TABLE courses 
    ADD create_by nvarchar(50) NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'delete_date'
)
BEGIN
	ALTER TABLE courses 
    ADD delete_Date datetime NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[courses]') 
         AND name = 'delete_by'
)
BEGIN
	ALTER TABLE courses 
    ADD delete_by varchar(50) NULL
END

-------------------------------

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[member_course]') 
         AND name = 'gradudate_yn'
)
BEGIN
	ALTER TABLE member_course 
    ADD graduate_yn varchar(1) NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[member_course]') 
         AND name = 'create_date'
)
BEGIN
	ALTER TABLE member_course 
    ADD create_date datetime NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[member_course]') 
         AND name = 'create_by'
)
BEGIN
	ALTER TABLE member_course 
    ADD create_by nvarchar(150) NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[member_course]') 
         AND name = 'delete_date'
)
BEGIN
	ALTER TABLE member_course 
    ADD delete_date datetime NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[member_course]') 
         AND name = 'delete_by'
)
BEGIN
	ALTER TABLE member_course 
    ADD delete_by nvarchar(150) NULL
END