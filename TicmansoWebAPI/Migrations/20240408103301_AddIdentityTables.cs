using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicmansoWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "TRIAL"),
                    country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "TRIAL"),
                    address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false, comment: "TRIAL"),
                    postalCode = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL"),
                    city = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "TRIAL"),
                    cif = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false, comment: "TRIAL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_company", x => x.id);
                },
                comment: "TRIAL");

            migrationBuilder.CreateTable(
                name: "priority",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_priority", x => x.id);
                },
                comment: "TRIAL");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false, comment: "TRIAL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role", x => x.id);
                },
                comment: "TRIAL");

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_status", x => x.id);
                },
                comment: "TRIAL");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    surnames = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    mail = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: false),
                    password = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    company_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_company1",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_user_role1",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id");
                },
                comment: "TRIAL");

            migrationBuilder.CreateTable(
                name: "chat",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    messages = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id1 = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chat", x => x.id);
                    table.ForeignKey(
                        name: "fk_chat_user1",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_chat_user2",
                        column: x => x.user_id1,
                        principalTable: "user",
                        principalColumn: "id");
                },
                comment: "TRIAL");

            migrationBuilder.CreateTable(
                name: "signing",
                columns: table => new
                {
                    date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "TRIAL"),
                    entry_time = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "TRIAL"),
                    departure_time = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "TRIAL"),
                    user_id = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_signing", x => x.date);
                    table.ForeignKey(
                        name: "signing_ibfk_1",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                },
                comment: "TRIAL");

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    changed_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    close_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    chat_id = table.Column<int>(type: "int", nullable: true),
                    priority_id = table.Column<long>(type: "bigint", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false),
                    creation_user_id = table.Column<long>(type: "bigint", nullable: false),
                    Support_user_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ticket", x => x.id);
                    table.ForeignKey(
                        name: "fk_ticket_priority1",
                        column: x => x.priority_id,
                        principalTable: "priority",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ticket_status1",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ticket_user1",
                        column: x => x.creation_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ticket_user2",
                        column: x => x.Support_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "ticket_ibfk_1",
                        column: x => x.chat_id,
                        principalTable: "chat",
                        principalColumn: "id");
                },
                comment: "TRIAL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "fk_chat_user1_idx",
                table: "chat",
                column: "user_id")
                .Annotation("SqlServer:FillFactor", 99);

            migrationBuilder.CreateIndex(
                name: "fk_chat_user2_idx",
                table: "chat",
                column: "user_id1")
                .Annotation("SqlServer:FillFactor", 99);

            migrationBuilder.CreateIndex(
                name: "idx_user_id",
                table: "signing",
                column: "user_id")
                .Annotation("SqlServer:FillFactor", 99);

            migrationBuilder.CreateIndex(
                name: "IX_ticket_chat_id",
                table: "ticket",
                column: "chat_id");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_creation_user_id",
                table: "ticket",
                column: "creation_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_priority_id",
                table: "ticket",
                column: "priority_id");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_status_id",
                table: "ticket",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_Support_user_id",
                table: "ticket",
                column: "Support_user_id");

            migrationBuilder.CreateIndex(
                name: "fk_user_company1_idx",
                table: "user",
                column: "company_id")
                .Annotation("SqlServer:FillFactor", 99);

            migrationBuilder.CreateIndex(
                name: "fk_user_role1_idx",
                table: "user",
                column: "role_id")
                .Annotation("SqlServer:FillFactor", 99);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "signing");

            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "priority");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "chat");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
