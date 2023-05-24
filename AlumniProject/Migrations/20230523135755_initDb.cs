using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumniProject.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOwner = table.Column<bool>(type: "bit", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImage_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhonePublicity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaceBook_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaceBookPublicity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    SubDomain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackGround1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackGround2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackGround3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestStatus = table.Column<bool>(type: "bit", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EvidenceUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagsNew",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsNew", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    AlumniId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Education_Alumni_AlumniId",
                        column: x => x.AlumniId,
                        principalTable: "Alumni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Major",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlumniId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Major_Alumni_AlumniId",
                        column: x => x.AlumniId,
                        principalTable: "Alumni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fund",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TargetBalance = table.Column<int>(type: "int", nullable: false),
                    BackgroundImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fund", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fund_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    SchoolId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_School_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "New",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    NewsImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPublic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlumniId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_New", x => x.Id);
                    table.ForeignKey(
                        name: "FK_New_Alumni_AlumniId",
                        column: x => x.AlumniId,
                        principalTable: "Alumni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_New_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlumniId = table.Column<int>(type: "int", nullable: false),
                    IsPublicSchool = table.Column<bool>(type: "bit", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.id);
                    table.ForeignKey(
                        name: "FK_Post_Alumni_AlumniId",
                        column: x => x.AlumniId,
                        principalTable: "Alumni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AlumniClasse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumniClasse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlumniClasse_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    IsOffline = table.Column<bool>(type: "bit", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublicPartictipant = table.Column<bool>(type: "bit", nullable: false),
                    IsPublicSchool = table.Column<bool>(type: "bit", nullable: false),
                    HostId = table.Column<int>(type: "int", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Alumni_HostId",
                        column: x => x.HostId,
                        principalTable: "Alumni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NewsTagNew",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsTagNew", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsTagNew_New_NewsId",
                        column: x => x.NewsId,
                        principalTable: "New",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsTagNew_TagsNew_TagsId",
                        column: x => x.TagsId,
                        principalTable: "TagsNew",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlunmniId = table.Column<int>(type: "int", nullable: false),
                    AlumniClassId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    AlumniId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessRequest_Alumni_AlumniId",
                        column: x => x.AlumniId,
                        principalTable: "Alumni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessRequest_AlumniClasse_AlumniClassId",
                        column: x => x.AlumniClassId,
                        principalTable: "AlumniClasse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlumniToClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumniId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumniToClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlumniToClass_Alumni_AlumniId",
                        column: x => x.AlumniId,
                        principalTable: "Alumni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumniToClass_AlumniClasse_ClassId",
                        column: x => x.ClassId,
                        principalTable: "AlumniClasse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventParticipant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    AlumniId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventParticipant_Alumni_AlumniId",
                        column: x => x.AlumniId,
                        principalTable: "Alumni",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventParticipant_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessRequest_AlumniClassId",
                table: "AccessRequest",
                column: "AlumniClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessRequest_AlumniId",
                table: "AccessRequest",
                column: "AlumniId");

            migrationBuilder.CreateIndex(
                name: "IX_AlumniClasse_GradeId",
                table: "AlumniClasse",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_AlumniToClass_AlumniId",
                table: "AlumniToClass",
                column: "AlumniId");

            migrationBuilder.CreateIndex(
                name: "IX_AlumniToClass_ClassId",
                table: "AlumniToClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_AlumniId",
                table: "Education",
                column: "AlumniId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_GradeId",
                table: "Event",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_HostId",
                table: "Event",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_SchoolId",
                table: "Event",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipant_AlumniId",
                table: "EventParticipant",
                column: "AlumniId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipant_EventId",
                table: "EventParticipant",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Fund_SchoolId",
                table: "Fund",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_SchoolId1",
                table: "Grade",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_Major_AlumniId",
                table: "Major",
                column: "AlumniId");

            migrationBuilder.CreateIndex(
                name: "IX_New_AlumniId",
                table: "New",
                column: "AlumniId");

            migrationBuilder.CreateIndex(
                name: "IX_New_SchoolId",
                table: "New",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsTagNew_NewsId",
                table: "NewsTagNew",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsTagNew_TagsId",
                table: "NewsTagNew",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_AlumniId",
                table: "Post",
                column: "AlumniId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_SchoolId",
                table: "Post",
                column: "SchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessRequest");

            migrationBuilder.DropTable(
                name: "AlumniToClass");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "EventParticipant");

            migrationBuilder.DropTable(
                name: "Fund");

            migrationBuilder.DropTable(
                name: "Major");

            migrationBuilder.DropTable(
                name: "NewsTagNew");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "AlumniClasse");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "New");

            migrationBuilder.DropTable(
                name: "TagsNew");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Alumni");

            migrationBuilder.DropTable(
                name: "School");
        }
    }
}
