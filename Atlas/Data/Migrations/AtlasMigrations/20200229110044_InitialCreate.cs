﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atlas.Data.Migrations.AtlasMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    TopicsCount = table.Column<int>(nullable: false),
                    RepliesCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SiteId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PermissionSetId = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => new { x.PermissionSetId, x.RoleId, x.Type });
                    table.ForeignKey(
                        name: "FK_Permission_PermissionSet_PermissionSetId",
                        column: x => x.PermissionSetId,
                        principalTable: "PermissionSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForumGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SiteId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    TopicsCount = table.Column<int>(nullable: false),
                    RepliesCounts = table.Column<int>(nullable: false),
                    PermissionSetId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumGroup_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Forum",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ForumGroupId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    TopicsCount = table.Column<int>(nullable: false),
                    RepliesCount = table.Column<int>(nullable: false),
                    PermissionSetId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forum_ForumGroup_ForumGroupId",
                        column: x => x.ForumGroupId,
                        principalTable: "ForumGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ForumId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    MemberId = table.Column<Guid>(nullable: false),
                    RepliesCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_Forum_ForumId",
                        column: x => x.ForumId,
                        principalTable: "Forum",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Topic_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reply",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TopicId = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    MemberId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reply_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reply_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forum_ForumGroupId",
                table: "Forum",
                column: "ForumGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumGroup_SiteId",
                table: "ForumGroup",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_MemberId",
                table: "Reply",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_TopicId",
                table: "Reply",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_ForumId",
                table: "Topic",
                column: "ForumId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_MemberId",
                table: "Topic",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Reply");

            migrationBuilder.DropTable(
                name: "PermissionSet");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Forum");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "ForumGroup");

            migrationBuilder.DropTable(
                name: "Site");
        }
    }
}
