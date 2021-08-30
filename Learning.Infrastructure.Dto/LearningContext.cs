using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Learning.Infrastructure.Dto
{
    public partial class LearningContext : DbContext
    {
        public LearningContext()
        {
        }

        public LearningContext(DbContextOptions<LearningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arrange> Arranges { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<AttendanceConfig> AttendanceConfigs { get; set; }
        public virtual DbSet<AttendanceDetail> AttendanceDetails { get; set; }
        public virtual DbSet<AttendanceSituation> AttendanceSituations { get; set; }
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<AttributeType> AttributeTypes { get; set; }
        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<ChapterRelation> ChapterRelations { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassConfig> ClassConfigs { get; set; }
        public virtual DbSet<ClassConfigDetail> ClassConfigDetails { get; set; }
        public virtual DbSet<ClassProject> ClassProjects { get; set; }
        public virtual DbSet<ClassProjectDetail> ClassProjectDetails { get; set; }
        public virtual DbSet<ClassRight> ClassRights { get; set; }
        public virtual DbSet<ClassRole> ClassRoles { get; set; }
        public virtual DbSet<ClassTeam> ClassTeams { get; set; }
        public virtual DbSet<ClassTeamDetail> ClassTeamDetails { get; set; }
        public virtual DbSet<ClassTeamProject> ClassTeamProjects { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Courseware> Coursewares { get; set; }
        public virtual DbSet<DutyArrange> DutyArranges { get; set; }
        public virtual DbSet<DutyHistory> DutyHistories { get; set; }
        public virtual DbSet<ExamArrange> ExamArranges { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationRelation> OrganizationRelations { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionBank> QuestionBanks { get; set; }
        public virtual DbSet<QuestionBankRelation> QuestionBankRelations { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Right> Rights { get; set; }
        public virtual DbSet<RightConfig> RightConfigs { get; set; }
        public virtual DbSet<RightConfigDetail> RightConfigDetails { get; set; }
        public virtual DbSet<RightsRelation> RightsRelations { get; set; }
        public virtual DbSet<Sign> Signs { get; set; }
        public virtual DbSet<TeachRelation> TeachRelations { get; set; }
        public virtual DbSet<TestPaper> TestPapers { get; set; }
        public virtual DbSet<TestPaperDetail> TestPaperDetails { get; set; }
        public virtual DbSet<TimeTable> TimeTables { get; set; }
        public virtual DbSet<Train> Trains { get; set; }
        public virtual DbSet<TrainPersonnel> TrainPersonnel { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserExam> UserExams { get; set; }
        public virtual DbSet<UserExamDetail> UserExamDetails { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<Work> Works { get; set; }
        public virtual DbSet<WorkDetail> WorkDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=1.15.254.172;Initial Catalog=Learning;User ID=gsl;Password=2Bi&ZgfVV!En4vj3");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_PRC_CI_AS");

            modelBuilder.Entity<Arrange>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK__Arrange__C69007C8AAA499F9");

                entity.ToTable("Arrange");

                entity.Property(e => e.Aid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AID");

                entity.Property(e => e.AauthorUid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AAuthorUID");

                entity.Property(e => e.AbackUpId)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("ABackUpID");

                entity.Property(e => e.AbeginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ABeginTime");

                entity.Property(e => e.Acids)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("ACids");

                entity.Property(e => e.AcreateTimeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ACreateTimeDate");

                entity.Property(e => e.Actids)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("ACTIDs")
                    .HasComment("团队ID");

                entity.Property(e => e.Adesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADesc");

                entity.Property(e => e.AendTime)
                    .HasColumnType("datetime")
                    .HasColumnName("AEndTime");

                entity.Property(e => e.Aexplain)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AExplain");

                entity.Property(e => e.AisDel).HasColumnName("AIsDel");

                entity.Property(e => e.AisExclude)
                    .HasColumnName("AIsExclude")
                    .HasComment("是否排斥其他安排,也就是说同一时间段只允许一个同类型安排");

                entity.Property(e => e.AisTrain).HasColumnName("AIsTrain");

                entity.Property(e => e.Aname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AName");

                entity.Property(e => e.ArelationId)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("ARelationID");

                entity.Property(e => e.Astate).HasColumnName("AState");

                entity.Property(e => e.AtypeAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ATypeAID");

                entity.Property(e => e.Auids)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("AUids");

                entity.HasOne(d => d.AauthorU)
                    .WithMany(p => p.Arranges)
                    .HasForeignKey(d => d.AauthorUid)
                    .HasConstraintName("FK_Arrange_AAuthorUID");

                entity.HasOne(d => d.AtypeA)
                    .WithMany(p => p.Arranges)
                    .HasForeignKey(d => d.AtypeAid)
                    .HasConstraintName("FK_Arrange_ATypeAID");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK__Attendan__C69007C8CE1F93DE");

                entity.ToTable("Attendance");

                entity.Property(e => e.Aid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AID");

                entity.Property(e => e.Aauthor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AAuthor")
                    .HasComment("添加人");

                entity.Property(e => e.Acid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACID")
                    .HasComment("班级ID");

                entity.Property(e => e.AcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACreateTime");

                entity.Property(e => e.Adate)
                    .HasColumnType("date")
                    .HasColumnName("ADate")
                    .HasComment("考勤日期");

                entity.Property(e => e.Adesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADesc");

                entity.Property(e => e.AisDel).HasColumnName("AIsDel");

                entity.Property(e => e.AlastTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ALastTime")
                    .HasComment("最后修改时间");

                entity.Property(e => e.Apercent)
                    .HasColumnName("APercent")
                    .HasComment("考勤百分比");

                entity.Property(e => e.Astate)
                    .HasColumnName("AState")
                    .HasComment("状态 保护是否确认等");

                entity.Property(e => e.AtimeSlotAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ATimeSlotAID")
                    .HasComment("考勤时间段 对应AID");

                entity.Property(e => e.AtypeAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ATypeAID")
                    .HasComment("考勤类型 对应AID");

                entity.HasOne(d => d.AauthorNavigation)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.Aauthor)
                    .HasConstraintName("FK_Attendance_AAuthor");

                entity.HasOne(d => d.Ac)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.Acid)
                    .HasConstraintName("FK_Attendance_ACID");

                entity.HasOne(d => d.AtimeSlotA)
                    .WithMany(p => p.AttendanceAtimeSlotAs)
                    .HasForeignKey(d => d.AtimeSlotAid)
                    .HasConstraintName("FK_Attendance_ATimeSlotAID");

                entity.HasOne(d => d.AtypeA)
                    .WithMany(p => p.AttendanceAtypeAs)
                    .HasForeignKey(d => d.AtypeAid)
                    .HasConstraintName("FK_Attendance_ATypeAID");
            });

            modelBuilder.Entity<AttendanceConfig>(entity =>
            {
                entity.HasKey(e => e.Acid)
                    .HasName("PK__Attendan__06FECA792BB36F78");

                entity.ToTable("AttendanceConfig");

                entity.Property(e => e.Acid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACID");

                entity.Property(e => e.AcbeginDate)
                    .HasColumnType("date")
                    .HasColumnName("ACBeginDate");

                entity.Property(e => e.AcbeginTime).HasColumnName("ACBeginTime");

                entity.Property(e => e.Accid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACCID");

                entity.Property(e => e.AccreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACCreateTime");

                entity.Property(e => e.Acdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACDesc");

                entity.Property(e => e.AcendDate)
                    .HasColumnType("date")
                    .HasColumnName("ACEndDate");

                entity.Property(e => e.AcendTime).HasColumnName("ACEndTime");

                entity.Property(e => e.Acflexible)
                    .HasColumnName("ACFlexible")
                    .HasComment("弹性时间 多少分钟");

                entity.Property(e => e.AcisDel)
                    .HasColumnName("ACIsDel")
                    .HasComment("考勤位置名称");

                entity.Property(e => e.Aclat)
                    .HasColumnName("ACLat")
                    .HasComment("纬度");

                entity.Property(e => e.Aclng)
                    .HasColumnName("ACLng")
                    .HasComment("经度");

                entity.Property(e => e.Acname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACName");

                entity.Property(e => e.AcpositionName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ACPositionName")
                    .HasComment("考勤位置名称");

                entity.Property(e => e.Acstate).HasColumnName("ACState");

                entity.Property(e => e.Actype)
                    .HasColumnName("ACType")
                    .HasComment("考勤类型 1:位置考勤 2:经纬度考勤 3:两者结合考勤");

                entity.Property(e => e.Acweeks)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ACWeeks");

                entity.Property(e => e.Acwucha)
                    .HasColumnName("ACWucha")
                    .HasComment("允许的误差值 多少米");

                entity.HasOne(d => d.Acc)
                    .WithMany(p => p.AttendanceConfigs)
                    .HasForeignKey(d => d.Accid)
                    .HasConstraintName("FK_AttendanceConfig_ACCID");
            });

            modelBuilder.Entity<AttendanceDetail>(entity =>
            {
                entity.HasKey(e => e.Adid)
                    .HasName("PK__Attendan__7930D5A0BBD20262");

                entity.Property(e => e.Adid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADID");

                entity.Property(e => e.Adaid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADAID")
                    .HasComment("对应考勤ID");

                entity.Property(e => e.Adasid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADASID")
                    .HasComment("如果不是正常状况 则需要指定对应状况的ID");

                entity.Property(e => e.Addesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADDesc");

                entity.Property(e => e.AdtypeAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADTypeAID")
                    .HasComment("出勤类型AID 正常 迟到等");

                entity.Property(e => e.Aduid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADUID")
                    .HasComment("用户ID");

                entity.HasOne(d => d.Ada)
                    .WithMany(p => p.AttendanceDetails)
                    .HasForeignKey(d => d.Adaid)
                    .HasConstraintName("FK_AttendanceDetails_ADAID");

                entity.HasOne(d => d.Adas)
                    .WithMany(p => p.AttendanceDetails)
                    .HasForeignKey(d => d.Adasid)
                    .HasConstraintName("FK_AttendanceDetails_ADASID");

                entity.HasOne(d => d.AdtypeA)
                    .WithMany(p => p.AttendanceDetails)
                    .HasForeignKey(d => d.AdtypeAid)
                    .HasConstraintName("FK_AttendanceDetails_ADTypeAID");

                entity.HasOne(d => d.Adu)
                    .WithMany(p => p.AttendanceDetails)
                    .HasForeignKey(d => d.Aduid)
                    .HasConstraintName("FK_AttendanceDetails_ADUID");
            });

            modelBuilder.Entity<AttendanceSituation>(entity =>
            {
                entity.HasKey(e => e.Asid)
                    .HasName("PK__Attendan__4DF619608F0DA636");

                entity.ToTable("AttendanceSituation");

                entity.Property(e => e.Asid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ASID");

                entity.Property(e => e.Asaid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ASAID")
                    .HasComment("对应考勤ID");

                entity.Property(e => e.AsbeginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ASBeginTime")
                    .HasComment("开始时间");

                entity.Property(e => e.Asdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ASDesc");

                entity.Property(e => e.AsendTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ASEndTime")
                    .HasComment("结束时间");

                entity.Property(e => e.Asstate)
                    .HasColumnName("ASState")
                    .HasComment("状态");

                entity.Property(e => e.AstypeAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ASTypeAID")
                    .HasComment("状况类型AID  迟到-旷课等");

                entity.Property(e => e.Asuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ASUID")
                    .HasComment("用户ID");

                entity.HasOne(d => d.Asa)
                    .WithMany(p => p.AttendanceSituations)
                    .HasForeignKey(d => d.Asaid)
                    .HasConstraintName("FK_AttendanceSituation_ASAID");

                entity.HasOne(d => d.AstypeA)
                    .WithMany(p => p.AttendanceSituations)
                    .HasForeignKey(d => d.AstypeAid)
                    .HasConstraintName("FK_AttendanceSituation_ASTypeAID");

                entity.HasOne(d => d.Asu)
                    .WithMany(p => p.AttendanceSituations)
                    .HasForeignKey(d => d.Asuid)
                    .HasConstraintName("FK_AttendanceSituation_ASUID");
            });

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK__Attribut__C69007C80F7B9093");

                entity.Property(e => e.Aid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AID");

                entity.Property(e => e.Aatid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AATID");

                entity.Property(e => e.AcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACreateTime");

                entity.Property(e => e.Adesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADesc");

                entity.Property(e => e.AisDel).HasColumnName("AIsDel");

                entity.Property(e => e.Aname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AName");

                entity.Property(e => e.Ano).HasColumnName("ANo");

                entity.Property(e => e.Astate).HasColumnName("AState");

                entity.Property(e => e.Auid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AUID");

                entity.Property(e => e.Avalue)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AValue");

                entity.Property(e => e.Avalue2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AValue2");

                entity.HasOne(d => d.Aat)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.Aatid)
                    .HasConstraintName("FK__Attribute__AATID__47A6A41B");

                entity.HasOne(d => d.Au)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.Auid)
                    .HasConstraintName("FK__Attributes__AUID__46B27FE2");
            });

            modelBuilder.Entity<AttributeType>(entity =>
            {
                entity.HasKey(e => e.Atid)
                    .HasName("PK__Attribut__4D3800A93B35936C");

                entity.ToTable("AttributeType");

                entity.HasIndex(e => e.Atvalue, "UQ__Attribut__0D5EC352FF54181D")
                    .IsUnique();

                entity.HasIndex(e => e.Atname, "UQ__Attribut__AE289F52D8B7748A")
                    .IsUnique();

                entity.Property(e => e.Atid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ATID");

                entity.Property(e => e.AtcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ATCreateTime");

                entity.Property(e => e.Atdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ATDesc");

                entity.Property(e => e.AtisDel).HasColumnName("ATIsDel");

                entity.Property(e => e.AtisNecessary).HasColumnName("ATIsNecessary");

                entity.Property(e => e.Atname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ATName");

                entity.Property(e => e.Atno).HasColumnName("ATNo");

                entity.Property(e => e.Atstate).HasColumnName("ATState");

                entity.Property(e => e.Atuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ATUID");

                entity.Property(e => e.Atvalue)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ATValue");

                entity.HasOne(d => d.Atu)
                    .WithMany(p => p.AttributeTypes)
                    .HasForeignKey(d => d.Atuid)
                    .HasConstraintName("FK__Attribute__ATUID__42E1EEFE");
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Chapter__C1F8DC599B46B8F1");

                entity.ToTable("Chapter");

                entity.Property(e => e.Cid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CID");

                entity.Property(e => e.Ccid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CCID")
                    .HasComment("对应课程ID");

                entity.Property(e => e.CclickCount).HasColumnName("CClickCount");

                entity.Property(e => e.CcommentCount)
                    .HasColumnName("CCommentCount")
                    .HasComment("评论数量");

                entity.Property(e => e.CcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CCreateTime");

                entity.Property(e => e.Cdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CDesc");

                entity.Property(e => e.CisDel).HasColumnName("CIsDel");

                entity.Property(e => e.Cname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CName")
                    .HasComment("章节名");

                entity.Property(e => e.Cno)
                    .HasColumnName("CNo")
                    .HasComment("序号");

                entity.Property(e => e.Cstate).HasColumnName("CState");

                entity.Property(e => e.CstudyCount)
                    .HasColumnName("CStudyCount")
                    .HasComment("学习数量");

                entity.HasOne(d => d.Cc)
                    .WithMany(p => p.Chapters)
                    .HasForeignKey(d => d.Ccid)
                    .HasConstraintName("FK_Chapter_CCID");
            });

            modelBuilder.Entity<ChapterRelation>(entity =>
            {
                entity.HasKey(e => e.Crid)
                    .HasName("PK__ChapterR__F2363F5299E2D171");

                entity.ToTable("ChapterRelation");

                entity.Property(e => e.Crid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRID");

                entity.Property(e => e.Crcid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRCID");

                entity.Property(e => e.CrcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CRCreateTime");

                entity.Property(e => e.Crcsid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRCSID");

                entity.Property(e => e.Crno).HasColumnName("CRNo");

                entity.Property(e => e.Crstate).HasColumnName("CRState");

                entity.HasOne(d => d.Crc)
                    .WithMany(p => p.ChapterRelations)
                    .HasForeignKey(d => d.Crcid)
                    .HasConstraintName("FK_ChapterRelation_CRCID");

                entity.HasOne(d => d.Crcs)
                    .WithMany(p => p.ChapterRelations)
                    .HasForeignKey(d => d.Crcsid)
                    .HasConstraintName("FK_ChapterRelation_CRCSID");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.HasIndex(e => e.Cname, "UQ__Classes__85D445AA96FF7EDB")
                    .IsUnique();

                entity.Property(e => e.Cid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CID");

                entity.Property(e => e.Ccount).HasColumnName("CCount");

                entity.Property(e => e.CcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CCreateTime");

                entity.Property(e => e.Cdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CDesc");

                entity.Property(e => e.CgradeAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CGradeAID");

                entity.Property(e => e.CisDel).HasColumnName("CIsDel");

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CName");

                entity.Property(e => e.Crid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRID");

                entity.Property(e => e.Cstate).HasColumnName("CState");

                entity.HasOne(d => d.CgradeA)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CgradeAid)
                    .HasConstraintName("FK_Classes_CGradeAID");

                entity.HasOne(d => d.Cr)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.Crid)
                    .HasConstraintName("FK_Classes_Resources");
            });

            modelBuilder.Entity<ClassConfig>(entity =>
            {
                entity.HasKey(e => e.Ccid)
                    .HasName("PK__ClassCon__A9561A4290A92B26");

                entity.ToTable("ClassConfig");

                entity.Property(e => e.Ccid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CCID");

                entity.Property(e => e.Ccauthor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CCAuthor");

                entity.Property(e => e.Cccid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CCCID");

                entity.Property(e => e.CccreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CCCreateTime");

                entity.Property(e => e.Ccdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CCDesc");

                entity.Property(e => e.Ccexplain)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CCExplain");

                entity.Property(e => e.CcisDel).HasColumnName("CCIsDel");

                entity.Property(e => e.CcisUse).HasColumnName("CCIsUse");

                entity.Property(e => e.Ccstate).HasColumnName("CCState");

                entity.Property(e => e.CctypeAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CCTypeAID");

                entity.HasOne(d => d.CcauthorNavigation)
                    .WithMany(p => p.ClassConfigs)
                    .HasForeignKey(d => d.Ccauthor)
                    .HasConstraintName("FK_ClassConfig_CCAuthor");

                entity.HasOne(d => d.CctypeA)
                    .WithMany(p => p.ClassConfigs)
                    .HasForeignKey(d => d.CctypeAid)
                    .HasConstraintName("FK_ClassConfig_CCTypeAID");
            });

            modelBuilder.Entity<ClassConfigDetail>(entity =>
            {
                entity.HasKey(e => e.Ccdid)
                    .HasName("PK__ClassCon__AB8548A88DF99B75");

                entity.Property(e => e.Ccdid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CCDID");

                entity.Property(e => e.Ccdauthor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CCDAuthor");

                entity.Property(e => e.CcdbeginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CCDBeginTime");

                entity.Property(e => e.Ccdccid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CCDCCID");

                entity.Property(e => e.CcdcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CCDCreateTime");

                entity.Property(e => e.Ccddesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CCDDesc");

                entity.Property(e => e.CcdendTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CCDEndTime");

                entity.Property(e => e.Ccdexplain)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CCDExplain");

                entity.Property(e => e.CcdisDel).HasColumnName("CCDIsDel");

                entity.Property(e => e.CcdisUse).HasColumnName("CCDIsUse");

                entity.Property(e => e.Ccdname)
                    .HasMaxLength(99)
                    .IsUnicode(false)
                    .HasColumnName("CCDName");

                entity.Property(e => e.Ccdno).HasColumnName("CCDNo");

                entity.Property(e => e.Ccdstate).HasColumnName("CCDState");

                entity.Property(e => e.Ccdvalue1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CCDValue1");

                entity.Property(e => e.Ccdvalue2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CCDValue2");

                entity.Property(e => e.Ccdvalue3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CCDValue3");

                entity.Property(e => e.Ccdvalue4)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CCDValue4");

                entity.HasOne(d => d.CcdauthorNavigation)
                    .WithMany(p => p.ClassConfigDetails)
                    .HasForeignKey(d => d.Ccdauthor)
                    .HasConstraintName("FK_ClassConfigDetails_CCDAuthor");

                entity.HasOne(d => d.Ccdcc)
                    .WithMany(p => p.ClassConfigDetails)
                    .HasForeignKey(d => d.Ccdccid)
                    .HasConstraintName("FK_ClassConfigDetails_CCDCCID");
            });

            modelBuilder.Entity<ClassProject>(entity =>
            {
                entity.HasKey(e => e.Cpid)
                    .HasName("PK__ClassPro__F5B22BE6089FBC1C");

                entity.ToTable("ClassProject");

                entity.Property(e => e.Cpid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CPID");

                entity.Property(e => e.CpauthorUid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CPAuthorUID");

                entity.Property(e => e.Cpcids)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("CPCIDs");

                entity.Property(e => e.CpcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CPCreateTime");

                entity.Property(e => e.Cpdays).HasColumnName("CPDays");

                entity.Property(e => e.Cpdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CPDesc");

                entity.Property(e => e.Cpexplain)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CPExplain");

                entity.Property(e => e.CpgradeAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CPGradeAID");

                entity.Property(e => e.CpisDel).HasColumnName("CPIsDel");

                entity.Property(e => e.CpisPublish).HasColumnName("CPIsPublish");

                entity.Property(e => e.CpisUse).HasColumnName("CPIsUse");

                entity.Property(e => e.Cplv).HasColumnName("CPLv");

                entity.Property(e => e.CpmaxCount).HasColumnName("CPMaxCount");

                entity.Property(e => e.CpminCount).HasColumnName("CPMinCount");

                entity.Property(e => e.Cpname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CPName");

                entity.Property(e => e.Cpstate).HasColumnName("CPState");

                entity.Property(e => e.CpsubjetAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CPSubjetAID");

                entity.Property(e => e.CptypeAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CPTypeAID");

                entity.HasOne(d => d.CpauthorU)
                    .WithMany(p => p.ClassProjects)
                    .HasForeignKey(d => d.CpauthorUid)
                    .HasConstraintName("FK_ClassProject_CPAuthorUID");

                entity.HasOne(d => d.CpgradeA)
                    .WithMany(p => p.ClassProjectCpgradeAs)
                    .HasForeignKey(d => d.CpgradeAid)
                    .HasConstraintName("FK_ClassProject_CPGradeAID");

                entity.HasOne(d => d.CpsubjetA)
                    .WithMany(p => p.ClassProjectCpsubjetAs)
                    .HasForeignKey(d => d.CpsubjetAid)
                    .HasConstraintName("FK_ClassProject_CPSubjetAID");

                entity.HasOne(d => d.CptypeA)
                    .WithMany(p => p.ClassProjectCptypeAs)
                    .HasForeignKey(d => d.CptypeAid)
                    .HasConstraintName("FK_ClassProject_CPTypeAID");
            });

            modelBuilder.Entity<ClassProjectDetail>(entity =>
            {
                entity.HasKey(e => e.Cpdid)
                    .HasName("PK__ClassPro__70FF1692514C9C94");

                entity.Property(e => e.Cpdid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CPDID");

                entity.Property(e => e.Cpcontent)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CPContent");

                entity.Property(e => e.CpcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CPCreateTime");

                entity.Property(e => e.Cpdays).HasColumnName("CPDays");

                entity.Property(e => e.Cpdcpid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CPDCPID");

                entity.Property(e => e.Cpno).HasColumnName("CPNo");

                entity.HasOne(d => d.Cpdcp)
                    .WithMany(p => p.ClassProjectDetails)
                    .HasForeignKey(d => d.Cpdcpid)
                    .HasConstraintName("FK_ClassProjectDetails_CPDCPID");
            });

            modelBuilder.Entity<ClassRight>(entity =>
            {
                entity.HasKey(e => e.Crid)
                    .HasName("PK__ClassRig__F2363F52D454301E");

                entity.ToTable("ClassRight");

                entity.Property(e => e.Crid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRID");

                entity.Property(e => e.CrcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CRCreateTime");

                entity.Property(e => e.Crdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CRDesc");

                entity.Property(e => e.CrrightAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRRightAID")
                    .HasComment("对应班级权限配置详情ID");

                entity.Property(e => e.CrroleCcdid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRRoleCCDID")
                    .HasComment("对应班级角色配置详情ID");

                entity.HasOne(d => d.CrrightA)
                    .WithMany(p => p.ClassRights)
                    .HasForeignKey(d => d.CrrightAid)
                    .HasConstraintName("FK_ClassRight_CRRightCCDID");

                entity.HasOne(d => d.CrroleCcd)
                    .WithMany(p => p.ClassRights)
                    .HasForeignKey(d => d.CrroleCcdid)
                    .HasConstraintName("FK_ClassRight_CRRoleCCDID");
            });

            modelBuilder.Entity<ClassRole>(entity =>
            {
                entity.HasKey(e => e.Crid)
                    .HasName("PK__ClassRol__F2363F5278776164");

                entity.ToTable("ClassRole");

                entity.Property(e => e.Crid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRID");

                entity.Property(e => e.Crccdid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRCCDID");

                entity.Property(e => e.Crcid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRCID");

                entity.Property(e => e.CrcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CRCreateTime");

                entity.Property(e => e.Crdesc)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CRDesc");

                entity.Property(e => e.CrisUse).HasColumnName("CRIsUse");

                entity.Property(e => e.Cruid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRUID");

                entity.HasOne(d => d.Crccd)
                    .WithMany(p => p.ClassRoles)
                    .HasForeignKey(d => d.Crccdid)
                    .HasConstraintName("FK_ClassRole_CRCCDID");

                entity.HasOne(d => d.Crc)
                    .WithMany(p => p.ClassRoles)
                    .HasForeignKey(d => d.Crcid)
                    .HasConstraintName("FK_ClassRole_CRCID");

                entity.HasOne(d => d.Cru)
                    .WithMany(p => p.ClassRoles)
                    .HasForeignKey(d => d.Cruid)
                    .HasConstraintName("FK_ClassRole_CRUID");
            });

            modelBuilder.Entity<ClassTeam>(entity =>
            {
                entity.HasKey(e => e.Ctid)
                    .HasName("PK__ClassTea__F4AA1BE0D3D69B01");

                entity.ToTable("ClassTeam");

                entity.Property(e => e.Ctid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CTID");

                entity.Property(e => e.CtcaptainAdjutantUid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CTCaptainAdjutantUID");

                entity.Property(e => e.CtcaptainUid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CTCaptainUID");

                entity.Property(e => e.Ctcid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CTCID");

                entity.Property(e => e.Ctcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CTCode");

                entity.Property(e => e.Ctcount).HasColumnName("CTCount");

                entity.Property(e => e.CtcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CTCreateTime");

                entity.Property(e => e.Ctdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CTDesc");

                entity.Property(e => e.Ctexplain)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CTExplain");

                entity.Property(e => e.CtisDel).HasColumnName("CTIsDel");

                entity.Property(e => e.CtisStart).HasColumnName("CTIsStart");

                entity.Property(e => e.CtlastTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CTLastTime");

                entity.Property(e => e.Ctname)
                    .HasMaxLength(99)
                    .IsUnicode(false)
                    .HasColumnName("CTName");

                entity.Property(e => e.Ctno).HasColumnName("CTNo");

                entity.Property(e => e.Ctstate).HasColumnName("CTState");

                entity.Property(e => e.CttypeAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CTTypeAID");

                entity.HasOne(d => d.CtcaptainAdjutantU)
                    .WithMany(p => p.ClassTeamCtcaptainAdjutantUs)
                    .HasForeignKey(d => d.CtcaptainAdjutantUid)
                    .HasConstraintName("FK_ClassTeam_CTCaptainAdjutantUID");

                entity.HasOne(d => d.CtcaptainU)
                    .WithMany(p => p.ClassTeamCtcaptainUs)
                    .HasForeignKey(d => d.CtcaptainUid)
                    .HasConstraintName("FK_ClassTeam_CTCaptainUID");

                entity.HasOne(d => d.Ctc)
                    .WithMany(p => p.ClassTeams)
                    .HasForeignKey(d => d.Ctcid)
                    .HasConstraintName("FK_ClassTeam_CTCID");

                entity.HasOne(d => d.CttypeA)
                    .WithMany(p => p.ClassTeams)
                    .HasForeignKey(d => d.CttypeAid)
                    .HasConstraintName("FK_ClassTeam_CTTypeAID");
            });

            modelBuilder.Entity<ClassTeamDetail>(entity =>
            {
                entity.HasKey(e => e.Ctdid)
                    .HasName("PK__ClassTea__D13B6255A523E82F");

                entity.Property(e => e.Ctdid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CTDID");

                entity.Property(e => e.Ctcid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CTCID");

                entity.Property(e => e.Ctdctid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CTDCTID");

                entity.Property(e => e.Ctdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CTDesc");

                entity.Property(e => e.Ctdgroup).HasColumnName("CTDGroup");

                entity.Property(e => e.CtdisLeader).HasColumnName("CTDIsLeader");

                entity.Property(e => e.Ctdno).HasColumnName("CTDNo");

                entity.Property(e => e.Ctdstate).HasColumnName("CTDState");

                entity.Property(e => e.Ctduid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CTDUID");

                entity.HasOne(d => d.Ctdct)
                    .WithMany(p => p.ClassTeamDetails)
                    .HasForeignKey(d => d.Ctdctid)
                    .HasConstraintName("FK_ClassTeamDetails_CTDCTID");

                entity.HasOne(d => d.Ctdu)
                    .WithMany(p => p.ClassTeamDetails)
                    .HasForeignKey(d => d.Ctduid)
                    .HasConstraintName("FK_ClassTeamDetails_CTDUID");
            });

            modelBuilder.Entity<ClassTeamProject>(entity =>
            {
                entity.HasKey(e => e.Ctpid)
                    .HasName("PK__ClassTea__D023105BC41C1535");

                entity.ToTable("ClassTeamProject");

                entity.Property(e => e.Ctpid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CTPID");

                entity.Property(e => e.CtpauthorUid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CTPAuthorUID");

                entity.Property(e => e.CtpbeginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CTPBeginTime");

                entity.Property(e => e.Ctpcpid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CTPCPID");

                entity.Property(e => e.CtpcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CTPCreateTime");

                entity.Property(e => e.Ctpctid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CTPCTID");

                entity.Property(e => e.Ctpdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CTPDesc");

                entity.Property(e => e.CtpendTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CTPEndTime");

                entity.Property(e => e.Ctpexplain)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CTPExplain");

                entity.Property(e => e.CtpisDel).HasColumnName("CTPIsDel");

                entity.Property(e => e.CtpisStart).HasColumnName("CTPIsStart");

                entity.Property(e => e.Ctpstate).HasColumnName("CTPState");

                entity.HasOne(d => d.CtpauthorU)
                    .WithMany(p => p.ClassTeamProjects)
                    .HasForeignKey(d => d.CtpauthorUid)
                    .HasConstraintName("FK_ClassTeamProject_CTPAuthorUID");

                entity.HasOne(d => d.Ctpcp)
                    .WithMany(p => p.ClassTeamProjects)
                    .HasForeignKey(d => d.Ctpcpid)
                    .HasConstraintName("FK_ClassTeamProject_CTPCPID");

                entity.HasOne(d => d.Ctpct)
                    .WithMany(p => p.ClassTeamProjects)
                    .HasForeignKey(d => d.Ctpctid)
                    .HasConstraintName("FK_ClassTeamProject_CTPCTID");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Courses__C1F8DC59DEA51143");

                entity.Property(e => e.Cid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CID");

                entity.Property(e => e.Cauthor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAuthor")
                    .HasComment("作者");

                entity.Property(e => e.CclickCount)
                    .HasColumnName("CClickCount")
                    .HasComment("点击数量");

                entity.Property(e => e.CcommentCount)
                    .HasColumnName("CCommentCount")
                    .HasComment("评论数量");

                entity.Property(e => e.Ccover)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CCover")
                    .HasComment("封面");

                entity.Property(e => e.CcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CCreateTime")
                    .HasComment("创建时间");

                entity.Property(e => e.Cdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CDesc");

                entity.Property(e => e.CisOpen).HasComment("是否公开");

                entity.Property(e => e.CisPublish)
                    .HasColumnName("CIsPublish")
                    .HasComment("是否发布");

                entity.Property(e => e.ClastTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CLastTime")
                    .HasComment("最后修改时间");

                entity.Property(e => e.Clv)
                    .HasColumnName("CLv")
                    .HasComment("等级");

                entity.Property(e => e.Cname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CName")
                    .HasComment("课程名称");

                entity.Property(e => e.Cprofile)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CProfile")
                    .HasComment("说明");

                entity.Property(e => e.Cstate)
                    .HasColumnName("CState")
                    .HasComment("状态");

                entity.Property(e => e.CstudyCount)
                    .HasColumnName("CStudyCount")
                    .HasComment("学习数量");

                entity.Property(e => e.CtypeAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CTypeAID")
                    .HasComment("类型AID");

                entity.HasOne(d => d.CauthorNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Cauthor)
                    .HasConstraintName("FK_Courses_CAuthor");

                entity.HasOne(d => d.CcoverNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Ccover)
                    .HasConstraintName("FK_Courses_CCover");

                entity.HasOne(d => d.CtypeA)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CtypeAid)
                    .HasConstraintName("FK_Courses_CTypeAID");
            });

            modelBuilder.Entity<Courseware>(entity =>
            {
                entity.HasKey(e => e.Cwid)
                    .HasName("PK__Coursewa__F5F0195BDF8A19A2");

                entity.ToTable("Courseware");

                entity.Property(e => e.Cwid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CWID");

                entity.Property(e => e.Cwauthor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CWAuthor");

                entity.Property(e => e.CwcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CWCreateTime");

                entity.Property(e => e.Cwdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CWDesc");

                entity.Property(e => e.CwisDel).HasColumnName("CWIsDel");

                entity.Property(e => e.CwisPublish).HasColumnName("CWIsPublish");

                entity.Property(e => e.Cwlabels)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("CWLabels");

                entity.Property(e => e.Cwname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CWName");

                entity.Property(e => e.CwpathRid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CWPathRID");

                entity.Property(e => e.Cwsize).HasColumnName("CWSize");

                entity.Property(e => e.Cwstate).HasColumnName("CWState");

                entity.Property(e => e.Cwtype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CWType");

                entity.HasOne(d => d.CwauthorNavigation)
                    .WithMany(p => p.Coursewares)
                    .HasForeignKey(d => d.Cwauthor)
                    .HasConstraintName("FK_Courseware_CSAuthor");

                entity.HasOne(d => d.CwpathR)
                    .WithMany(p => p.Coursewares)
                    .HasForeignKey(d => d.CwpathRid)
                    .HasConstraintName("FK_CourseWare_CWPathRID");
            });

            modelBuilder.Entity<DutyArrange>(entity =>
            {
                entity.HasKey(e => e.Daid)
                    .HasName("PK__DutyArra__1F7DE965937AD389");

                entity.ToTable("DutyArrange");

                entity.Property(e => e.Daid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DAID");

                entity.Property(e => e.Dacid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DACID");

                entity.Property(e => e.DacompletAuthor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DACompletAuthor");

                entity.Property(e => e.DacompletDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DACompletDate");

                entity.Property(e => e.Dadate)
                    .HasColumnType("date")
                    .HasColumnName("DADate");

                entity.Property(e => e.Dadesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DADesc");

                entity.Property(e => e.Dadhid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DADHID");

                entity.Property(e => e.DaisDel).HasColumnName("DAIsDel");

                entity.Property(e => e.DalastTime)
                    .HasColumnType("datetime")
                    .HasColumnName("DALastTime");

                entity.Property(e => e.Danames)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DANames");

                entity.Property(e => e.Dastate).HasColumnName("DAState");

                entity.Property(e => e.Dauids)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DAUIDs");

                entity.HasOne(d => d.Dac)
                    .WithMany(p => p.DutyArranges)
                    .HasForeignKey(d => d.Dacid)
                    .HasConstraintName("FK_DutyArrange_Classes");

                entity.HasOne(d => d.DacompletAuthorNavigation)
                    .WithMany(p => p.DutyArranges)
                    .HasForeignKey(d => d.DacompletAuthor)
                    .HasConstraintName("FK_DutyArrange_DACompletAuthor");

                entity.HasOne(d => d.Dadh)
                    .WithMany(p => p.DutyArranges)
                    .HasForeignKey(d => d.Dadhid)
                    .HasConstraintName("FK_DutyArrange_DADHID");
            });

            modelBuilder.Entity<DutyHistory>(entity =>
            {
                entity.HasKey(e => e.Dhid)
                    .HasName("PK__DutyHist__2971B07D90C005A2");

                entity.ToTable("DutyHistory");

                entity.Property(e => e.Dhid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DHID");

                entity.Property(e => e.Dhauthor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DHAuthor");

                entity.Property(e => e.DhbeginDate)
                    .HasColumnType("date")
                    .HasColumnName("DHBeginDate")
                    .HasComment("本轮值日开始时间");

                entity.Property(e => e.Dhcid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DHCID");

                entity.Property(e => e.Dhcount)
                    .HasColumnName("DHCount")
                    .HasComment("本轮值日 总次数");

                entity.Property(e => e.DhcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("DHCreateTime");

                entity.Property(e => e.Dhdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DHDesc");

                entity.Property(e => e.DhendDate)
                    .HasColumnType("date")
                    .HasColumnName("DHEndDate")
                    .HasComment("本轮值日结束时间");

                entity.Property(e => e.Dhinning)
                    .HasColumnName("DHInning")
                    .HasComment("轮次,班级值日轮次");

                entity.Property(e => e.DhisDel).HasColumnName("DHIsDel");

                entity.Property(e => e.Dhnames)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("DHNames");

                entity.Property(e => e.Dhstate).HasColumnName("DHState");

                entity.HasOne(d => d.DhauthorNavigation)
                    .WithMany(p => p.DutyHistories)
                    .HasForeignKey(d => d.Dhauthor)
                    .HasConstraintName("FK_DutyHistory_DHAuthor");

                entity.HasOne(d => d.Dhc)
                    .WithMany(p => p.DutyHistories)
                    .HasForeignKey(d => d.Dhcid)
                    .HasConstraintName("FK_DutyHistory_DHCID");
            });

            modelBuilder.Entity<ExamArrange>(entity =>
            {
                entity.HasKey(e => e.Eaid)
                    .HasName("PK__ExamArra__DFB6FAF8E238B08C");

                entity.ToTable("ExamArrange");

                entity.Property(e => e.Eaid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EAID");

                entity.Property(e => e.Eaauthor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EAAuthor")
                    .HasComment("安排人");

                entity.Property(e => e.EabeginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("EABeginTime")
                    .HasComment("考试开始时间");

                entity.Property(e => e.EacheckUid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EACheckUID")
                    .HasComment("阅卷人");

                entity.Property(e => e.Eacids)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("EACIDS")
                    .HasComment("安排考试的班级ID列表");

                entity.Property(e => e.EacreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("EACreateTime");

                entity.Property(e => e.Eadesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EADesc");

                entity.Property(e => e.EaendTime)
                    .HasColumnType("datetime")
                    .HasColumnName("EAEndTime")
                    .HasComment("考试结束时间");

                entity.Property(e => e.EaisDel).HasColumnName("EAIsDel");

                entity.Property(e => e.Eaname)
                    .HasMaxLength(99)
                    .IsUnicode(false)
                    .HasColumnName("EAName")
                    .HasComment("安排名称");

                entity.Property(e => e.Eastate).HasColumnName("EAState");

                entity.Property(e => e.Eatpid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EATPID")
                    .HasComment("试卷ID");

                entity.Property(e => e.Eauids)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("EAUIDS")
                    .HasComment("安排考试的用户ID列表");

                entity.HasOne(d => d.EaauthorNavigation)
                    .WithMany(p => p.ExamArrangeEaauthorNavigations)
                    .HasForeignKey(d => d.Eaauthor)
                    .HasConstraintName("FK_ExamArrange_EAAuthor");

                entity.HasOne(d => d.EacheckU)
                    .WithMany(p => p.ExamArrangeEacheckUs)
                    .HasForeignKey(d => d.EacheckUid)
                    .HasConstraintName("FK_ExamArrange_EACheckUID");

                entity.HasOne(d => d.Eatp)
                    .WithMany(p => p.ExamArranges)
                    .HasForeignKey(d => d.Eatpid)
                    .HasConstraintName("FK_ExamArrange_EATPID");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("History");

                entity.Property(e => e.Haction)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HAction");

                entity.Property(e => e.HcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("HCreateTime");

                entity.Property(e => e.Hdesc)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("HDesc");

                entity.Property(e => e.Hid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HID");

                entity.Property(e => e.HisFinish).HasColumnName("HIsFinish");

                entity.Property(e => e.Hno).HasColumnName("HNo");

                entity.Property(e => e.Htable)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HTable");

                entity.Property(e => e.HthemeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HThemeID");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("PK__Options__CB394B391A31D9F6");

                entity.Property(e => e.Oid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Ocontent)
                    .HasColumnType("ntext")
                    .HasColumnName("OContent")
                    .HasComment("选项内容");

                entity.Property(e => e.Odesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ODesc");

                entity.Property(e => e.OisDel).HasColumnName("OIsDel");

                entity.Property(e => e.OisRight)
                    .HasColumnName("OIsRight")
                    .HasComment("是否正确答案");

                entity.Property(e => e.Oqid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OQID");

                entity.Property(e => e.Ostate).HasColumnName("OState");

                entity.HasOne(d => d.Oq)
                    .WithMany(p => p.Options)
                    .HasForeignKey(d => d.Oqid)
                    .HasConstraintName("FK_Option_OQID");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("PK__Organiza__CB394B39EEA181C5");

                entity.ToTable("Organization");

                entity.HasIndex(e => e.Oname, "UQ__Organiza__B106EB575F68F797")
                    .IsUnique();

                entity.Property(e => e.Oid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.OcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("OCreateTime");

                entity.Property(e => e.Odesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ODesc");

                entity.Property(e => e.Oexplain)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("OExplain");

                entity.Property(e => e.OisDel).HasColumnName("OIsDel");

                entity.Property(e => e.Olv).HasColumnName("OLv");

                entity.Property(e => e.Oname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OName");

                entity.Property(e => e.Ono).HasColumnName("ONo");

                entity.Property(e => e.OparentOid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OParentOID");

                entity.Property(e => e.Oprincipal)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("OPrincipal");

                entity.Property(e => e.Ostate).HasColumnName("OState");
            });

            modelBuilder.Entity<OrganizationRelation>(entity =>
            {
                entity.HasKey(e => e.Orid)
                    .HasName("PK__Organiza__A9A8BCD6B6C40B50");

                entity.ToTable("OrganizationRelation");

                entity.Property(e => e.Orid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ORID");

                entity.Property(e => e.OrcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ORCreateTime");

                entity.Property(e => e.Ordesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ORDesc");

                entity.Property(e => e.OrisPrincipal).HasColumnName("ORIsPrincipal");

                entity.Property(e => e.Oroid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OROID");

                entity.Property(e => e.Orstate).HasColumnName("ORState");

                entity.Property(e => e.Oruid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ORUID");

                entity.HasOne(d => d.Oro)
                    .WithMany(p => p.OrganizationRelations)
                    .HasForeignKey(d => d.Oroid)
                    .HasConstraintName("FK_OrganizationRelation_OROID");

                entity.HasOne(d => d.Oru)
                    .WithMany(p => p.OrganizationRelations)
                    .HasForeignKey(d => d.Oruid)
                    .HasConstraintName("FK_OrganizationRelation_ORUID");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.Qid)
                    .HasName("PK__Question__CAB147CBB75995FE");

                entity.ToTable("Question");

                entity.Property(e => e.Qid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QID");

                entity.Property(e => e.Qauthor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QAuthor")
                    .HasComment("作者");

                entity.Property(e => e.Qcontent)
                    .IsUnicode(false)
                    .HasColumnName("QContent")
                    .HasComment("题干");

                entity.Property(e => e.QcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("QCreateTime");

                entity.Property(e => e.Qdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("QDesc");

                entity.Property(e => e.QisDel).HasColumnName("QIsDel");

                entity.Property(e => e.QisPublish)
                    .HasColumnName("QIsPublish")
                    .HasComment("是否发布");

                entity.Property(e => e.QisSubjective)
                    .HasColumnName("QIsSubjective")
                    .HasComment("是否主观题");

                entity.Property(e => e.Qlabels)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("QLabels")
                    .HasComment("试题标签列表,应该使用属性表ID");

                entity.Property(e => e.Qlv)
                    .HasColumnName("QLv")
                    .HasComment("难度等级 1-10");

                entity.Property(e => e.Qstate).HasColumnName("QState");

                entity.Property(e => e.QtypeAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QTypeAID")
                    .HasComment("题目类型");

                entity.Property(e => e.QupdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("QUpdateTime");

                entity.HasOne(d => d.QauthorNavigation)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.Qauthor)
                    .HasConstraintName("FK_Question_QAuthor");

                entity.HasOne(d => d.QtypeA)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QtypeAid)
                    .HasConstraintName("FK_Question_QTypeAID");
            });

            modelBuilder.Entity<QuestionBank>(entity =>
            {
                entity.HasKey(e => e.Qbid)
                    .HasName("PK__Question__DFE79DB995AE2C25");

                entity.ToTable("QuestionBank");

                entity.Property(e => e.Qbid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QBID");

                entity.Property(e => e.Qbauthor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QBAuthor");

                entity.Property(e => e.QbcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("QBCreateTime");

                entity.Property(e => e.Qbdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("QBDesc");

                entity.Property(e => e.Qbexplain)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("QBExplain");

                entity.Property(e => e.QbisPublish).HasColumnName("QBIsPublish");

                entity.Property(e => e.QbisReadonly).HasColumnName("QBIsReadonly");

                entity.Property(e => e.Qbname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QBName");

                entity.Property(e => e.Qbstate).HasColumnName("QBState");

                entity.Property(e => e.QbtypeAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QBTypeAID");

                entity.Property(e => e.QbupdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("QBUpdateTime");

                entity.HasOne(d => d.QbauthorNavigation)
                    .WithMany(p => p.QuestionBanks)
                    .HasForeignKey(d => d.Qbauthor)
                    .HasConstraintName("FK_QuestionBank_QBAuthor");

                entity.HasOne(d => d.QbtypeA)
                    .WithMany(p => p.QuestionBanks)
                    .HasForeignKey(d => d.QbtypeAid)
                    .HasConstraintName("FK_QuestionBank_QBTypeAID");
            });

            modelBuilder.Entity<QuestionBankRelation>(entity =>
            {
                entity.HasKey(e => e.Qbrid)
                    .HasName("PK__Question__88CC0CBE0FA7A6E4");

                entity.ToTable("QuestionBankRelation");

                entity.Property(e => e.Qbrid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QBRID");

                entity.Property(e => e.Qbdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("QBDesc");

                entity.Property(e => e.Qbrauthor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QBRAuthor");

                entity.Property(e => e.QbrcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("QBRCreateTime");

                entity.Property(e => e.Qbrqbid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QBRQBID");

                entity.Property(e => e.Qbrqid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QBRQID");

                entity.Property(e => e.Qbstate).HasColumnName("QBState");

                entity.HasOne(d => d.Qbrqb)
                    .WithMany(p => p.QuestionBankRelations)
                    .HasForeignKey(d => d.Qbrqbid)
                    .HasConstraintName("FK_QuestionBankRelation_QBRQBID");

                entity.HasOne(d => d.Qbrq)
                    .WithMany(p => p.QuestionBankRelations)
                    .HasForeignKey(d => d.Qbrqid)
                    .HasConstraintName("FK_QuestionBankRelation_QBRQID");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.Rid)
                    .HasName("PK__Resource__CAFF41326210E85E");

                entity.Property(e => e.Rid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RID");

                entity.Property(e => e.Raid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RAID");

                entity.Property(e => e.RbeginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("RBeginTime");

                entity.Property(e => e.RcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("RCreateTime");

                entity.Property(e => e.Rdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RDesc");

                entity.Property(e => e.RendTime)
                    .HasColumnType("datetime")
                    .HasColumnName("REndTime");

                entity.Property(e => e.RisDel).HasColumnName("RIsDel");

                entity.Property(e => e.RisPublic).HasColumnName("RIsPublic");

                entity.Property(e => e.RisUse).HasColumnName("RIsUse");

                entity.Property(e => e.Rname)
                    .HasMaxLength(99)
                    .IsUnicode(false)
                    .HasColumnName("RName");

                entity.Property(e => e.Rpath)
                    .HasMaxLength(900)
                    .IsUnicode(false)
                    .HasColumnName("RPath");

                entity.Property(e => e.Rsize).HasColumnName("RSize");

                entity.Property(e => e.Rstate).HasColumnName("RState");

                entity.Property(e => e.Rtitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RTitle");

                entity.Property(e => e.Ruid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RUID");

                entity.HasOne(d => d.Ra)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.Raid)
                    .HasConstraintName("FK_Resources_Attributes");

                entity.HasOne(d => d.Ru)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.Ruid)
                    .HasConstraintName("FK_Resources_RAID");
            });

            modelBuilder.Entity<Right>(entity =>
            {
                entity.HasKey(e => e.Rid)
                    .HasName("PK__Rights__CAFF41321880C8EE");

                entity.Property(e => e.Rid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RID");

                entity.Property(e => e.RcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("RCreateTime");

                entity.Property(e => e.Rdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RDesc");

                entity.Property(e => e.Rexplain)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("RExplain");

                entity.Property(e => e.Ricon)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RIcon");

                entity.Property(e => e.RisDel).HasColumnName("RIsDel");

                entity.Property(e => e.RisMenu)
                    .HasColumnName("RIsMenu")
                    .HasComment("是否显示在菜单栏");

                entity.Property(e => e.RisNecessary).HasColumnName("RIsNecessary");

                entity.Property(e => e.Rlv).HasColumnName("RLv");

                entity.Property(e => e.Rname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RName");

                entity.Property(e => e.Rno).HasColumnName("RNo");

                entity.Property(e => e.RprentRid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RPrentRID");

                entity.Property(e => e.Rstate).HasColumnName("RState");

                entity.Property(e => e.Rurl)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("RURL");

                entity.HasOne(d => d.RprentR)
                    .WithMany(p => p.InverseRprentR)
                    .HasForeignKey(d => d.RprentRid)
                    .HasConstraintName("FK_Rights_Rights1");
            });

            modelBuilder.Entity<RightConfig>(entity =>
            {
                entity.HasKey(e => e.Rcid)
                    .HasName("PK__RightCon__45CAE2110FE1B9D2");

                entity.ToTable("RightConfig");

                entity.HasIndex(e => e.Rcname, "UQ__RightCon__D2EAF7E02A7BCA4C")
                    .IsUnique();

                entity.Property(e => e.Rcid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RCID");

                entity.Property(e => e.Rcaid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RCAID");

                entity.Property(e => e.RccreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("RCCreateTime");

                entity.Property(e => e.Rcdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RCDesc");

                entity.Property(e => e.RcisDel).HasColumnName("RCIsDel");

                entity.Property(e => e.Rcname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RCName");

                entity.Property(e => e.Rcstate).HasColumnName("RCState");

                entity.HasOne(d => d.Rca)
                    .WithMany(p => p.RightConfigs)
                    .HasForeignKey(d => d.Rcaid)
                    .HasConstraintName("FK__RightConf__RCAID__3493CFA7");
            });

            modelBuilder.Entity<RightConfigDetail>(entity =>
            {
                entity.HasKey(e => e.Rcdid)
                    .HasName("PK__RightCon__5851B50EE5291EA8");

                entity.Property(e => e.Rcdid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RCDID");

                entity.Property(e => e.Rcdrcid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RCDRCID");

                entity.Property(e => e.Rcrid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RCRID");

                entity.HasOne(d => d.Rcdrc)
                    .WithMany(p => p.RightConfigDetails)
                    .HasForeignKey(d => d.Rcdrcid)
                    .HasConstraintName("FK__RightConf__RCDRC__3587F3E0");

                entity.HasOne(d => d.Rcr)
                    .WithMany(p => p.RightConfigDetails)
                    .HasForeignKey(d => d.Rcrid)
                    .HasConstraintName("FK__RightConf__RCRID__37703C52");
            });

            modelBuilder.Entity<RightsRelation>(entity =>
            {
                entity.HasKey(e => e.Rrid)
                    .HasName("PK__RightsRe__E3054D136E1BE7E6");

                entity.ToTable("RightsRelation");

                entity.Property(e => e.Rrid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RRID");

                entity.Property(e => e.Rrauthor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RRAuthor");

                entity.Property(e => e.RrbeginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("RRBeginTime");

                entity.Property(e => e.RrcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("RRCreateTime");

                entity.Property(e => e.Rrdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RRDesc");

                entity.Property(e => e.RrendTime)
                    .HasColumnType("datetime")
                    .HasColumnName("RREndTime");

                entity.Property(e => e.RrisDel).HasColumnName("RRIsDel");

                entity.Property(e => e.Rrrid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RRRID");

                entity.Property(e => e.Rrstate).HasColumnName("RRState");

                entity.Property(e => e.Rruid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RRUID");

                entity.HasOne(d => d.RrauthorNavigation)
                    .WithMany(p => p.RightsRelationRrauthorNavigations)
                    .HasForeignKey(d => d.Rrauthor)
                    .HasConstraintName("FK__RightsRel__RRAut__6D9742D9");

                entity.HasOne(d => d.Rrr)
                    .WithMany(p => p.RightsRelations)
                    .HasForeignKey(d => d.Rrrid)
                    .HasConstraintName("FK__RightsRel__RRRID__6CA31EA0");

                entity.HasOne(d => d.Rru)
                    .WithMany(p => p.RightsRelationRrus)
                    .HasForeignKey(d => d.Rruid)
                    .HasConstraintName("FK__RightsRel__RRUID__6BAEFA67");
            });

            modelBuilder.Entity<Sign>(entity =>
            {
                entity.HasKey(e => e.Sgid);

                entity.ToTable("Sign");

                entity.Property(e => e.Sgid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SGID")
                    .HasComment("验证码ID");

                entity.Property(e => e.Sgaid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SGAID")
                    .HasComment("验证码类型ID");

                entity.Property(e => e.Sgcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SGCode")
                    .HasComment("验证码本码");

                entity.Property(e => e.SgcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("SGCreateTime")
                    .HasComment("创建时间");

                entity.Property(e => e.Sgdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SGDesc")
                    .HasComment("说明");

                entity.Property(e => e.SgendTime)
                    .HasColumnType("datetime")
                    .HasColumnName("SGEndTime")
                    .HasComment("有效时间");

                entity.Property(e => e.Sgip)
                    .HasMaxLength(99)
                    .IsUnicode(false)
                    .HasColumnName("SGIP");

                entity.Property(e => e.SgisDel).HasColumnName("SGIsDel");

                entity.Property(e => e.Sgphone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SGPhone")
                    .HasComment("手机号码");

                entity.Property(e => e.Sgstate)
                    .HasColumnName("SGState")
                    .HasComment("状态");

                entity.Property(e => e.SguseTime)
                    .HasColumnType("datetime")
                    .HasColumnName("SGUseTime")
                    .HasComment("使用时间");

                entity.HasOne(d => d.Sga)
                    .WithMany(p => p.Signs)
                    .HasForeignKey(d => d.Sgaid)
                    .HasConstraintName("FK_Sign_Attributes");
            });

            modelBuilder.Entity<TeachRelation>(entity =>
            {
                entity.HasKey(e => e.Trid)
                    .HasName("PK__TeachRel__82F3BB35A0065986");

                entity.ToTable("TeachRelation");

                entity.Property(e => e.Trid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRID");

                entity.Property(e => e.TrclassCid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRClassCID");

                entity.Property(e => e.TrcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("TRCreateTime");

                entity.Property(e => e.Trdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TRDesc");

                entity.Property(e => e.TrendTime)
                    .HasColumnType("datetime")
                    .HasColumnName("TREndTime");

                entity.Property(e => e.Trexplain)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TRExplain");

                entity.Property(e => e.TrisDel).HasColumnName("TRIsDel");

                entity.Property(e => e.Trstate).HasColumnName("TRState");

                entity.Property(e => e.TrteacherUid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRTeacherUID");

                entity.Property(e => e.TrtypeAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRTypeAID");

                entity.HasOne(d => d.TrclassC)
                    .WithMany(p => p.TeachRelations)
                    .HasForeignKey(d => d.TrclassCid)
                    .HasConstraintName("FK_Teacher_TRClassCID");

                entity.HasOne(d => d.TrteacherU)
                    .WithMany(p => p.TeachRelations)
                    .HasForeignKey(d => d.TrteacherUid)
                    .HasConstraintName("FK_Teacher_TRTeacherUID");

                entity.HasOne(d => d.TrtypeA)
                    .WithMany(p => p.TeachRelations)
                    .HasForeignKey(d => d.TrtypeAid)
                    .HasConstraintName("FK_Teacher_TRTypeAID");
            });

            modelBuilder.Entity<TestPaper>(entity =>
            {
                entity.HasKey(e => e.Tpid)
                    .HasName("PK__TestPape__A0726B4AEB963CE6");

                entity.ToTable("TestPaper");

                entity.Property(e => e.Tpid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TPID");

                entity.Property(e => e.Tpaction)
                    .HasColumnName("TPAction")
                    .HasComment("组卷方式 1:人工组卷  2:随机组卷  3:人工+随机组卷");

                entity.Property(e => e.Tpauthor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TPAuthor")
                    .HasComment("试卷作者");

                entity.Property(e => e.Tpcids)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("TPCIDs");

                entity.Property(e => e.TpcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("TPCreateTime");

                entity.Property(e => e.Tpdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TPDesc");

                entity.Property(e => e.TpisDel).HasColumnName("TPIsDel");

                entity.Property(e => e.TpisPublish)
                    .HasColumnName("TPIsPublish")
                    .HasComment("是否发布");

                entity.Property(e => e.Tplabels)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("TPLabels")
                    .HasComment("试卷标签");

                entity.Property(e => e.Tplv)
                    .HasColumnName("TPLv")
                    .HasComment("试卷难度");

                entity.Property(e => e.Tpname)
                    .HasMaxLength(99)
                    .IsUnicode(false)
                    .HasColumnName("TPName");

                entity.Property(e => e.TppassScore).HasColumnName("TPPassScore");

                entity.Property(e => e.Tpqcount)
                    .HasColumnName("TPQCount")
                    .HasComment("总题目数");

                entity.Property(e => e.Tpstate).HasColumnName("TPState");

                entity.Property(e => e.TptotalScore)
                    .HasColumnName("TPTotalScore")
                    .HasComment("总分");

                entity.Property(e => e.TptypeAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TPTypeAID")
                    .HasComment("试卷类型");

                entity.HasOne(d => d.TpauthorNavigation)
                    .WithMany(p => p.TestPapers)
                    .HasForeignKey(d => d.Tpauthor)
                    .HasConstraintName("FK_TestPaper_TPAuthor");

                entity.HasOne(d => d.TptypeA)
                    .WithMany(p => p.TestPapers)
                    .HasForeignKey(d => d.TptypeAid)
                    .HasConstraintName("FK_TestPaper_TPTypeAID");
            });

            modelBuilder.Entity<TestPaperDetail>(entity =>
            {
                entity.HasKey(e => e.Tpdid)
                    .HasName("PK__TestPape__66820825509CC9E8");

                entity.Property(e => e.Tpdid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TPDID");

                entity.Property(e => e.Tpdqid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TPDQID")
                    .HasComment("试题ID");

                entity.Property(e => e.Tpdscore).HasColumnName("TPDScore");

                entity.Property(e => e.Tpdtpid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TPDTPID")
                    .HasComment("试卷ID");

                entity.HasOne(d => d.Tpdq)
                    .WithMany(p => p.TestPaperDetails)
                    .HasForeignKey(d => d.Tpdqid)
                    .HasConstraintName("FK_TestPaperDetails_TPDQID");

                entity.HasOne(d => d.Tpdtp)
                    .WithMany(p => p.TestPaperDetails)
                    .HasForeignKey(d => d.Tpdtpid)
                    .HasConstraintName("FK_TestPaperDetails_TPDTPID");
            });

            modelBuilder.Entity<TimeTable>(entity =>
            {
                entity.HasKey(e => e.Ttid)
                    .HasName("PK__TimeTabl__837B9FC79145F28C");

                entity.ToTable("TimeTable");

                entity.Property(e => e.Ttid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TTID");

                entity.Property(e => e.Ttam)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TTAM");

                entity.Property(e => e.Ttauthor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TTAuthor");

                entity.Property(e => e.Ttcid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TTCID");

                entity.Property(e => e.TtcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("TTCreateTime");

                entity.Property(e => e.Ttdate)
                    .HasColumnType("date")
                    .HasColumnName("TTDate");

                entity.Property(e => e.Ttdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TTDesc");

                entity.Property(e => e.TtisDel).HasColumnName("TTIsDel");

                entity.Property(e => e.Ttnight)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TTNight");

                entity.Property(e => e.Ttpm)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TTPM");

                entity.Property(e => e.Ttstate).HasColumnName("TTState");

                entity.HasOne(d => d.TtauthorNavigation)
                    .WithMany(p => p.TimeTables)
                    .HasForeignKey(d => d.Ttauthor)
                    .HasConstraintName("FK_TimeTable_TTAuthor");

                entity.HasOne(d => d.Ttc)
                    .WithMany(p => p.TimeTables)
                    .HasForeignKey(d => d.Ttcid)
                    .HasConstraintName("FK_TimeTable_TTCID");
            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.HasKey(e => e.Tid)
                    .HasName("PK__Train__C456D729F8EA61CE");

                entity.ToTable("Train");

                entity.HasIndex(e => e.Tname, "UQ__Train__8E5169F5342201D8")
                    .IsUnique();

                entity.Property(e => e.Tid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TID");

                entity.Property(e => e.TbeginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("TBeginTime");

                entity.Property(e => e.Tcount).HasColumnName("TCount");

                entity.Property(e => e.TcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("TCreateTime");

                entity.Property(e => e.Tdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TDesc");

                entity.Property(e => e.TdutyPeopleUid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TDutyPeopleUID");

                entity.Property(e => e.TendTime)
                    .HasColumnType("datetime")
                    .HasColumnName("TEndTime");

                entity.Property(e => e.TisDel).HasColumnName("TIsDel");

                entity.Property(e => e.Tname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TName");

                entity.Property(e => e.Tstate).HasColumnName("TState");

                entity.Property(e => e.TtypeAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TTypeAID");

                entity.HasOne(d => d.TdutyPeopleU)
                    .WithMany(p => p.Trains)
                    .HasForeignKey(d => d.TdutyPeopleUid)
                    .HasConstraintName("FK_Train_TDutyPepleUID");

                entity.HasOne(d => d.TtypeA)
                    .WithMany(p => p.Trains)
                    .HasForeignKey(d => d.TtypeAid)
                    .HasConstraintName("FK_Train_TTypeAID");
            });

            modelBuilder.Entity<TrainPersonnel>(entity =>
            {
                entity.HasKey(e => e.Tpid)
                    .HasName("PK__TrainPer__A0726B4A6211E4DC");

                entity.Property(e => e.Tpid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TPID");

                entity.Property(e => e.Tpcomment)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TPComment");

                entity.Property(e => e.TpcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("TPCreateTime");

                entity.Property(e => e.Tpdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TPDesc");

                entity.Property(e => e.Tpresult).HasColumnName("TPResult");

                entity.Property(e => e.Tpscore).HasColumnName("TPScore");

                entity.Property(e => e.Tpstate).HasColumnName("TPState");

                entity.Property(e => e.Tptid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TPTID");

                entity.Property(e => e.Tpuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TPUID");

                entity.Property(e => e.TpupdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("TPUpdateTime");

                entity.HasOne(d => d.Tpt)
                    .WithMany(p => p.TrainPersonnel)
                    .HasForeignKey(d => d.Tptid)
                    .HasConstraintName("FK_TrainPersonnel_TPTID");

                entity.HasOne(d => d.Tpu)
                    .WithMany(p => p.TrainPersonnel)
                    .HasForeignKey(d => d.Tpuid)
                    .HasConstraintName("FK_TrainPersonnel_TPUID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__Users__C5B196023BE6B4CE");

                entity.HasIndex(e => e.Uaccount, "UQ__Users__4A352460652B1FC2")
                    .IsUnique();

                entity.Property(e => e.Uid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UID");

                entity.Property(e => e.Uaccount)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UAccount");

                entity.Property(e => e.Ucid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UCID");

                entity.Property(e => e.Ucode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UCode");

                entity.Property(e => e.UcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UCreateTime");

                entity.Property(e => e.Udesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UDesc");

                entity.Property(e => e.UdesignationAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UDesignationAID");

                entity.Property(e => e.UisDel).HasColumnName("UIsDel");

                entity.Property(e => e.Ulabels)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("ULabels");

                entity.Property(e => e.UlastIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ULastIP");

                entity.Property(e => e.UlastTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ULastTime");

                entity.Property(e => e.Ulv).HasColumnName("ULv");

                entity.Property(e => e.Uname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UName");

                entity.Property(e => e.UopenId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UOpenID");

                entity.Property(e => e.Upassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPassword");

                entity.Property(e => e.UroleAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("URoleAID");

                entity.Property(e => e.Usign)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USign")
                    .HasComment("当前验证码,最后一次发送的验证码ID");

                entity.Property(e => e.Ustate).HasColumnName("UState");

                entity.HasOne(d => d.Uc)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Ucid)
                    .HasConstraintName("FK_Users_Classes");

                entity.HasOne(d => d.UdesignationA)
                    .WithMany(p => p.UserUdesignationAs)
                    .HasForeignKey(d => d.UdesignationAid)
                    .HasConstraintName("FK_Users_UDesignationAID");

                entity.HasOne(d => d.UroleA)
                    .WithMany(p => p.UserUroleAs)
                    .HasForeignKey(d => d.UroleAid)
                    .HasConstraintName("FK_Users_Attributes");

                entity.HasOne(d => d.UsignNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Usign)
                    .HasConstraintName("FK_Users_Sign");
            });

            modelBuilder.Entity<UserExam>(entity =>
            {
                entity.HasKey(e => e.Ueid)
                    .HasName("PK__UserExam__B6E17FD04E9DDAA2");

                entity.ToTable("UserExam");

                entity.Property(e => e.Ueid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UEID");

                entity.Property(e => e.UecheckUid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UECheckUID");

                entity.Property(e => e.Uecode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UECode")
                    .HasComment("考试代码,每次进入考试都会重新生成,如果交卷时代码不同则无法进行交卷");

                entity.Property(e => e.UecreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UECreateTime");

                entity.Property(e => e.Uedesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UEDesc");

                entity.Property(e => e.Ueeaid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UEEAID")
                    .HasComment("安排考试ID");

                entity.Property(e => e.UefinishTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UEFinishTime")
                    .HasComment("考生 结束考试时间 交卷时间");

                entity.Property(e => e.UeisDel).HasColumnName("UEIsDel");

                entity.Property(e => e.Uescore)
                    .HasColumnName("UEScore")
                    .HasComment("考试得分");

                entity.Property(e => e.UestartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UEStartTime")
                    .HasComment("考生 开始考试时间");

                entity.Property(e => e.Uestate).HasColumnName("UEState");

                entity.Property(e => e.Ueuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UEUID")
                    .HasComment("考生ID");

                entity.HasOne(d => d.UecheckU)
                    .WithMany(p => p.UserExamUecheckUs)
                    .HasForeignKey(d => d.UecheckUid)
                    .HasConstraintName("FK_UserExam_UECheckUID");

                entity.HasOne(d => d.Ueea)
                    .WithMany(p => p.UserExams)
                    .HasForeignKey(d => d.Ueeaid)
                    .HasConstraintName("FK_Exam_EEAID");

                entity.HasOne(d => d.Ueu)
                    .WithMany(p => p.UserExamUeus)
                    .HasForeignKey(d => d.Ueuid)
                    .HasConstraintName("FK_Exam_EUID");
            });

            modelBuilder.Entity<UserExamDetail>(entity =>
            {
                entity.HasKey(e => e.Uedid)
                    .HasName("PK__UserExam__483BC7E26AC80DCE");

                entity.Property(e => e.Uedid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UEDID");

                entity.Property(e => e.Uedanswers)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("UEDAnswers");

                entity.Property(e => e.Ueddesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UEDDesc");

                entity.Property(e => e.Uedeid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UEDEID");

                entity.Property(e => e.UedisRight).HasColumnName("UEDIsRight");

                entity.Property(e => e.Uedqid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UEDQID");

                entity.Property(e => e.Uescore).HasColumnName("UEScore");

                entity.HasOne(d => d.Uede)
                    .WithMany(p => p.UserExamDetails)
                    .HasForeignKey(d => d.Uedeid)
                    .HasConstraintName("FK_ExamDetails_EDEID");

                entity.HasOne(d => d.Uedq)
                    .WithMany(p => p.UserExamDetails)
                    .HasForeignKey(d => d.Uedqid)
                    .HasConstraintName("FK_ExamDetails_EDQID");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.Uiid)
                    .HasName("PK__UserInfo__B1FE7ED314912289");

                entity.ToTable("UserInfo");

                entity.Property(e => e.Uiid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UIID");

                entity.Property(e => e.Uibirthday)
                    .HasColumnType("datetime")
                    .HasColumnName("UIBirthday");

                entity.Property(e => e.UicreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UICreateTime");

                entity.Property(e => e.Uidesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UIDesc");

                entity.Property(e => e.Uigender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UIGender");

                entity.Property(e => e.Uigrade)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UIGrade");

                entity.Property(e => e.UiisDel).HasColumnName("UIIsDel");

                entity.Property(e => e.Uimail)
                    .HasMaxLength(99)
                    .IsUnicode(false)
                    .HasColumnName("UIMail");

                entity.Property(e => e.Uinick)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UINick");

                entity.Property(e => e.Uiphone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UIPhone");

                entity.Property(e => e.Uipoint).HasColumnName("UIPoint");

                entity.Property(e => e.Uirid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UIRID");

                entity.Property(e => e.Uistate).HasColumnName("UIState");

                entity.Property(e => e.Uiuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UIUID");

                entity.HasOne(d => d.Uir)
                    .WithMany(p => p.UserInfos)
                    .HasForeignKey(d => d.Uirid)
                    .HasConstraintName("FK_UserInfo_UIRID");

                entity.HasOne(d => d.Uiu)
                    .WithMany(p => p.UserInfos)
                    .HasForeignKey(d => d.Uiuid)
                    .HasConstraintName("FK_UserInfo_UIUID");
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.HasKey(e => e.Wid)
                    .HasName("PK__Work__DB376519DFE0874A");

                entity.ToTable("Work");

                entity.Property(e => e.Wid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WID");

                entity.Property(e => e.Wcid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WCID");

                entity.Property(e => e.Wcontent)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("WContent");

                entity.Property(e => e.WcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("WCreateTime");

                entity.Property(e => e.Wdate)
                    .HasColumnType("date")
                    .HasColumnName("WDate");

                entity.Property(e => e.Wdesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("WDesc");

                entity.Property(e => e.WisDel).HasColumnName("WIsDel");

                entity.Property(e => e.WlastTime)
                    .HasColumnType("datetime")
                    .HasColumnName("WLastTime");

                entity.Property(e => e.Wname)
                    .HasMaxLength(99)
                    .IsUnicode(false)
                    .HasColumnName("WName");

                entity.Property(e => e.Wstate).HasColumnName("WState");

                entity.Property(e => e.WsubjectAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WSubjectAID");

                entity.Property(e => e.Wtype)
                    .HasMaxLength(99)
                    .IsUnicode(false)
                    .HasColumnName("WType");

                entity.HasOne(d => d.Wc)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.Wcid)
                    .HasConstraintName("FK__Work__WCID__6D0D32F4");

                entity.HasOne(d => d.WsubjectA)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.WsubjectAid)
                    .HasConstraintName("FK__Work__WSubjectAI__6C190EBB");
            });

            modelBuilder.Entity<WorkDetail>(entity =>
            {
                entity.HasKey(e => e.Wdid)
                    .HasName("PK__WorkDeta__FF53040AFB401FB0");

                entity.Property(e => e.Wdid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WDID");

                entity.Property(e => e.WdcreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("WDCreateTime");

                entity.Property(e => e.WdisDel).HasColumnName("WDIsDel");

                entity.Property(e => e.Wdstate).HasColumnName("WDState");

                entity.Property(e => e.Wduid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WDUID");

                entity.Property(e => e.Wdwid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WDWID");

                entity.HasOne(d => d.Wdu)
                    .WithMany(p => p.WorkDetails)
                    .HasForeignKey(d => d.Wduid)
                    .HasConstraintName("FK__WorkDetai__WDUID__70DDC3D8");

                entity.HasOne(d => d.Wdw)
                    .WithMany(p => p.WorkDetails)
                    .HasForeignKey(d => d.Wdwid)
                    .HasConstraintName("FK__WorkDetai__WDWID__6FE99F9F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
