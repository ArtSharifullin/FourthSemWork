using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Spovest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdentityId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Img = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    IsWithdrawBlocked = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BalanceHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalBalance = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Img = table.Column<string>(type: "text", nullable: false),
                    Games = table.Column<int>(type: "integer", nullable: false),
                    Points = table.Column<decimal>(type: "numeric", nullable: false),
                    Assists = table.Column<decimal>(type: "numeric", nullable: false),
                    Rebounds = table.Column<decimal>(type: "numeric", nullable: false),
                    Steals = table.Column<decimal>(type: "numeric", nullable: false),
                    Minutes = table.Column<decimal>(type: "numeric", nullable: false),
                    Ftps = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Img = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Purchase_price = table.Column<decimal>(type: "numeric", nullable: true),
                    Sale_price = table.Column<decimal>(type: "numeric", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Img = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    OperationType = table.Column<int>(type: "integer", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppUserId = table.Column<int>(type: "integer", nullable: false),
                    FollowerId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_AppUsers_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: false),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PriceAtAdd = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Assists", "CreatedBy", "CreatedDate", "Ftps", "Games", "Img", "Minutes", "Name", "Points", "Rebounds", "Steals", "TeamId", "TeamName", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 7.8m, null, null, 0.73m, 72, "/images/player_search/avatar_3.png", 36.2m, "Lebron James", 28.5m, 8.3m, 1.6m, 1, "Los Angeles Lakers", null, null },
                    { 2, 3.1m, null, null, 0.78m, 65, "/images/player_search/avatar_5.png", 32.5m, "Anthony Davis", 22.4m, 10.2m, 1.8m, 1, "Los Angeles Lakers", null, null },
                    { 3, 8.4m, null, null, 0.67m, 70, "/images/player_search/avatar_1.png", 34.0m, "Russell Westbrook", 18.2m, 7.5m, 1.3m, 1, "Los Angeles Lakers", null, null },
                    { 4, 6.2m, null, null, 0.82m, 68, "/images/player_search/avatar_6.png", 29.8m, "D'Angelo Russell", 15.3m, 3.4m, 1.1m, 1, "Los Angeles Lakers", null, null },
                    { 5, 2.9m, null, null, 0.85m, 60, "/images/player_search/avatar_2.png", 21.4m, "Austin Reaves", 9.7m, 2.8m, 0.9m, 1, "Los Angeles Lakers", null, null },
                    { 6, 6.5m, null, null, 0.91m, 67, "/images/player_search/avatar_1.png", 34.7m, "Stephen Curry", 31.2m, 5.5m, 1.2m, 2, "Golden State Warriors", null, null },
                    { 7, 3.2m, null, null, 0.87m, 62, "/images/player_search/avatar_6.png", 31.0m, "Klay Thompson", 21.5m, 3.9m, 1.3m, 2, "Golden State Warriors", null, null },
                    { 8, 6.9m, null, null, 0.65m, 64, "/images/player_search/avatar_2.png", 28.3m, "Draymond Green", 8.5m, 7.1m, 1.5m, 2, "Golden State Warriors", null, null },
                    { 9, 3.4m, null, null, 0.76m, 66, "/images/player_search/avatar_3.png", 30.1m, "Andrew Wiggins", 17.3m, 5.2m, 1.0m, 2, "Golden State Warriors", null, null },
                    { 10, 8.8m, null, null, 0.83m, 58, "/images/player_search/avatar_5.png", 29.5m, "Chris Paul", 14.2m, 4.1m, 1.7m, 2, "Golden State Warriors", null, null },
                    { 11, 4.9m, null, null, 0.86m, 74, "/images/player_search/avatar_5.png", 36.5m, "Jayson Tatum", 30.1m, 9.2m, 1.4m, 3, "Boston Celtics", null, null },
                    { 12, 3.5m, null, null, 0.80m, 70, "/images/player_search/avatar_3.png", 33.2m, "Jaylen Brown", 24.6m, 6.3m, 1.3m, 3, "Boston Celtics", null, null },
                    { 13, 2.1m, null, null, 0.82m, 58, "/images/player_search/avatar_2.png", 28.7m, "Kristaps Porzingis", 20.4m, 8.9m, 1.2m, 3, "Boston Celtics", null, null },
                    { 14, 4.0m, null, null, 0.85m, 65, "/images/player_search/avatar_1.png", 26.4m, "Derrick White", 11.2m, 3.1m, 1.0m, 3, "Boston Celtics", null, null },
                    { 15, 2.8m, null, null, 0.79m, 60, "/images/player_search/avatar_6.png", 24.1m, "Al Horford", 9.5m, 7.2m, 0.8m, 3, "Boston Celtics", null, null },
                    { 16, 5.4m, null, null, 0.90m, 70, "/images/player_search/avatar_6.png", 35.9m, "Kevin Durant", 29.8m, 7.3m, 1.1m, 4, "Brooklyn Nets", null, null },
                    { 17, 6.5m, null, null, 0.55m, 55, "/images/player_search/avatar_1.png", 27.3m, "Ben Simmons", 6.8m, 6.1m, 1.4m, 4, "Brooklyn Nets", null, null },
                    { 18, 3.2m, null, null, 0.83m, 68, "/images/player_search/avatar_2.png", 33.0m, "Mikal Bridges", 19.4m, 4.8m, 1.6m, 4, "Brooklyn Nets", null, null },
                    { 19, 5.7m, null, null, 0.81m, 62, "/images/player_search/avatar_5.png", 28.4m, "Spencer Dinwiddie", 13.6m, 2.9m, 0.9m, 4, "Brooklyn Nets", null, null },
                    { 20, 2.4m, null, null, 0.92m, 64, "/images/player_search/avatar_3.png", 23.9m, "Seth Curry", 11.5m, 2.1m, 0.7m, 4, "Brooklyn Nets", null, null },
                    { 21, 5.4m, null, null, 0.84m, 69, "/images/player_search/avatar_3.png", 34.8m, "Jimmy Butler", 22.6m, 5.8m, 2.1m, 5, "Miami Heat", null, null },
                    { 22, 3.5m, null, null, 0.77m, 71, "/images/player_search/avatar_2.png", 33.6m, "Bam Adebayo", 20.1m, 9.4m, 1.3m, 5, "Miami Heat", null, null },
                    { 23, 4.3m, null, null, 0.86m, 66, "/images/player_search/avatar_6.png", 32.1m, "Tyler Herro", 21.2m, 5.1m, 1.0m, 5, "Miami Heat", null, null },
                    { 24, 2.1m, null, null, 0.88m, 63, "/images/player_search/avatar_1.png", 24.5m, "Max Strus", 9.8m, 3.2m, 0.8m, 5, "Miami Heat", null, null },
                    { 25, 2.3m, null, null, 0.85m, 58, "/images/player_search/avatar_5.png", 19.8m, "Gabe Vincent", 7.4m, 2.0m, 0.9m, 5, "Miami Heat", null, null },
                    { 26, 8.7m, null, null, 0.83m, 74, "/images/player_search/avatar_5.png", 33.7m, "Nikola Jokic", 24.5m, 10.8m, 1.3m, 6, "Denver Nuggets", null, null },
                    { 27, 6.1m, null, null, 0.89m, 68, "/images/player_search/avatar_1.png", 32.6m, "Jamal Murray", 20.3m, 4.5m, 1.4m, 6, "Denver Nuggets", null, null },
                    { 28, 3.8m, null, null, 0.76m, 70, "/images/player_search/avatar_2.png", 31.5m, "Aaron Gordon", 17.2m, 6.9m, 1.1m, 6, "Denver Nuggets", null, null },
                    { 29, 1.9m, null, null, 0.87m, 60, "/images/player_search/avatar_6.png", 27.4m, "Michael Porter Jr.", 14.1m, 6.3m, 0.9m, 6, "Denver Nuggets", null, null },
                    { 30, 2.5m, null, null, 0.80m, 67, "/images/player_search/avatar_3.png", 25.8m, "Kentavious Caldwell-Pope", 10.2m, 3.4m, 1.2m, 6, "Denver Nuggets", null, null }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "Img", "Title", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Не ожидал настолько хорошей игры, повешу счет игры в рамочке на стену !!!", null, null, "/images/user/stat.png", "Поднял бабло на баскетболе", null, null, 1 },
                    { 2, "Опыт растёт с каждой игрой, теперь понимаю, где стоит рисковать, а где лучше подождать.", null, null, null, "Больше не боюсь делать ставки", null, null, 1 },
                    { 3, "Но не расстроен, зато теперь знаю, как это работает на деле.", null, null, "/images/user/stat.png", "Поставил на проигравшую команду", null, null, 2 },
                    { 4, "Раньше не особо разбирался в баскетболе, а сейчас даже прогнозы читаю перед матчами.", null, null, null, "Стало интереснее следить за спортом", null, null, 2 },
                    { 5, "Это был шикарный момент! Теперь верю в свои силы и играю увереннее.", null, null, "/images/user/stat.png", "Выиграл первый крупный куш!", null, null, 3 },
                    { 6, "Требует внимания и анализа, но когда всё сходится — адреналин зашкаливает!", null, null, null, "Сложная игра, но очень увлекательная", null, null, 3 },
                    { 7, "Всё было почти идеально, но в последние минуты всё пошло не так...", null, null, "/images/user/stat.png", "Обидное поражение", null, null, 4 },
                    { 8, "Раньше действовал наугад, теперь проверяю форму игроков и результаты предыдущих встреч.", null, null, null, "Учу статистику перед ставками", null, null, 4 },
                    { 9, "Изучил несколько подходов, адаптировал под себя — теперь стабильный плюс в кошельке.", null, null, "/images/user/stat.png", "Моя стратегия начала работать", null, null, 5 },
                    { 10, "Главное — не гнаться за большими выигрышами, а держаться плана.", null, null, null, "Играю аккуратно, но уверенно", null, null, 5 },
                    { 11, "Научился анализировать, стал больше понимать в спорте, чем раньше.", null, null, "/images/user/stat.png", "Крутой опыт за эти пару месяцев", null, null, 6 },
                    { 12, "Теперь они тоже начали интересоваться, советуются по ставкам.", null, null, null, "Делюсь опытом с друзьями", null, null, 6 },
                    { 13, "Уже несколько раз помогала выйти в плюс даже при небольших потерях.", null, null, "/images/user/stat.png", "Фора оказалась моим спасением", null, null, 7 },
                    { 14, "Анализирую матчи, слежу за новостями, веду свою статистику — весело и полезно.", null, null, null, "Играть стало как хобби", null, null, 7 },
                    { 15, "Проиграл, но без фанатизма, теперь буду учиться на этом опыте.", null, null, "/images/user/stat.png", "Первый минус, но не последний", null, null, 8 },
                    { 16, "Пробую разные подходы, экспериментирую с суммами и выбором событий.", null, null, null, "Ищу свой стиль игры", null, null, 8 },
                    { 17, "Раньше гнался за высокими цифрами, теперь выбираю более реальные варианты.", null, null, "/images/user/stat.png", "Стал осторожнее с коэффициентами", null, null, 9 },
                    { 18, "Думаю развивать это дальше, может, станет проектом на постоянной основе.", null, null, null, "Создал телеграм-канал для обмена опытом", null, null, 9 },
                    { 19, "Это добавляет адреналина, особенно если игра идет напряжённо до самого конца.", null, null, "/images/user/stat.png", "Люблю делать ставки в прямом эфире", null, null, 10 },
                    { 20, "Теперь каждый момент важен, пытаюсь предсказать развитие событий.", null, null, null, "Смотрю матчи уже совсем по-другому", null, null, 10 }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "PlayerId", "Purchase_price", "Sale_price", "Timestamp", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, null, 1, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 2, null, null, 2, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 3, null, null, 3, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 4, null, null, 4, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 5, null, null, 5, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 6, null, null, 6, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 7, null, null, 7, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 8, null, null, 8, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 9, null, null, 9, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 10, null, null, 10, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 11, null, null, 11, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 12, null, null, 12, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 13, null, null, 13, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 14, null, null, 14, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 15, null, null, 15, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 16, null, null, 16, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 17, null, null, 17, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 18, null, null, 18, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 19, null, null, 19, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 20, null, null, 20, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 21, null, null, 21, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 22, null, null, 22, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 23, null, null, 23, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 24, null, null, 24, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 25, null, null, 25, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 26, null, null, 26, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 27, null, null, 27, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 28, null, null, 28, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 29, null, null, 29, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 30, null, null, 30, 5m, 5m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 31, null, null, 1, 12m, 10m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 32, null, null, 2, 7m, 8m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 33, null, null, 3, 15m, 14m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 34, null, null, 4, 5m, 6m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 35, null, null, 5, 19m, 17m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 36, null, null, 6, 3m, 4m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 37, null, null, 7, 9m, 9m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 38, null, null, 8, 2m, 3m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 39, null, null, 9, 16m, 15m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 40, null, null, 10, 6m, 7m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 41, null, null, 11, 10m, 10m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 42, null, null, 12, 4m, 5m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 43, null, null, 13, 18m, 16m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 44, null, null, 14, 8m, 9m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 45, null, null, 15, 1m, 2m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 46, null, null, 16, 14m, 13m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 47, null, null, 17, 11m, 12m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 48, null, null, 18, 5m, 5m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 49, null, null, 19, 7m, 8m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 50, null, null, 20, 13m, 12m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 51, null, null, 21, 9m, 10m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 52, null, null, 22, 3m, 4m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 53, null, null, 23, 17m, 15m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 54, null, null, 24, 6m, 7m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 55, null, null, 25, 2m, 3m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 56, null, null, 26, 10m, 9m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 57, null, null, 27, 8m, 8m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 58, null, null, 28, 4m, 5m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 59, null, null, 29, 15m, 14m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { 60, null, null, 30, 7m, 6m, new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, null }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Img", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, null, "/images/teams/lakers.png", "Los Angeles Lakers", null, null },
                    { 2, null, null, "/images/teams/gsw.png", "Golden State Warriors", null, null },
                    { 3, null, null, "/images/teams/bc.png", "Boston Celtics", null, null },
                    { 4, null, null, "/images/teams/bn.png", "Brooklyn Nets", null, null },
                    { 5, null, null, "/images/teams/mh.png", "Miami Heat", null, null },
                    { 6, null, null, "/images/teams/dn.png", "Denver Nuggets", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_AppUserId",
                table: "CartItems",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_PlayerId",
                table: "CartItems",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_AppUserId",
                table: "Subscriptions",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_FollowerId",
                table: "Subscriptions",
                column: "FollowerId");
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
                name: "BalanceHistory");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
