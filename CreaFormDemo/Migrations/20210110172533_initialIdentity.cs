using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreaFormDemo.Migrations
{
    public partial class initialIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    UserIdThatCreatedit = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Livs stil område",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livs stil område", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Läkemedel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Läkemedel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    anledningtillmedicineringen = table.Column<string>(name: "anledning till medicineringen", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Läkemedel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Plus minus grupp",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gruppnamn = table.Column<string>(name: " Grupp namn", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plus minus grupp", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "programPlans",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramNumber = table.Column<int>(type: "int", nullable: false),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Water = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WholeGrains = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatsOils1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CookFromScratch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GentleCooking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirdLeanFishShellFish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatFish1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Egg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DarkGreenLeafyVegetables = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Legumes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VegetablesOver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fruit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Berries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NutsAlmondsSeedsNatural = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Herbs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Variation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SweetDrinks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SweetsSugaryFoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefinedGrain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatsOils2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FastFoodReadyMealsSemiFinishedProducts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestructiveCooking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessedMeat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatFish2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coffee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DairyProducts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootVegetablesSome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedMeat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealHabits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecoveryStress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stimulants = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodAsMedicine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Variousips = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programPlans", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Styrka-Brist Grupp",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gruppnamn = table.Column<string>(name: " Grupp namn", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styrka-Brist Grupp", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "Rådgivare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rådgivare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rådgivare_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arbete Kategori",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriNamn = table.Column<string>(name: "Kategori Namn", type: "nvarchar(max)", nullable: true),
                    Livsstilområde = table.Column<int>(name: "Livs stil område", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbete Kategori", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Arbete Kategori_Livs stil område_Livs stil område",
                        column: x => x.Livsstilområde,
                        principalTable: "Livs stil område",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Privat kategori",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategorinamn = table.Column<string>(name: "Kategori namn", type: "nvarchar(max)", nullable: true),
                    Livsstilområde = table.Column<int>(name: "Livs stil område", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privat kategori", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Privat kategori_Livs stil område_Livs stil område",
                        column: x => x.Livsstilområde,
                        principalTable: "Livs stil område",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vanors kategori",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kategorisNamn = table.Column<string>(name: "kategoris Namn", type: "nvarchar(max)", nullable: true),
                    Livsstilområde = table.Column<int>(name: "Livs stil område", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vanors kategori", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vanors kategori_Livs stil område_Livs stil område",
                        column: x => x.Livsstilområde,
                        principalTable: "Livs stil område",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plus minus under grupp",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    undergrupp = table.Column<string>(name: " under grupp", type: "nvarchar(max)", nullable: true),
                    PlusminusgruppID = table.Column<int>(name: " Plus minus grupp ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plus minus under grupp", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Plus minus under grupp_Plus minus grupp_ Plus minus grupp ID",
                        column: x => x.PlusminusgruppID,
                        principalTable: "Plus minus grupp",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Styrka-Brist under Grupp",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beskrivning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyrkaBristGruppID = table.Column<int>(name: "Styrka-Brist Grupp ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styrka-Brist under Grupp", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Styrka-Brist under Grupp_Styrka-Brist Grupp_Styrka-Brist Grupp ID",
                        column: x => x.StyrkaBristGruppID,
                        principalTable: "Styrka-Brist Grupp",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ärföretagskonto = table.Column<bool>(name: "Är företagskonto", type: "bit", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    RådgivareID = table.Column<int>(name: "Rådgivare ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Klient_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Klient_Rådgivare_Rådgivare ID",
                        column: x => x.RådgivareID,
                        principalTable: "Rådgivare",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Arbete frågor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Frågetext = table.Column<string>(name: "Fråge text", type: "nvarchar(max)", nullable: true),
                    KategoriID = table.Column<int>(name: "Kategori ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbete frågor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Arbete frågor_Arbete Kategori_Kategori ID",
                        column: x => x.KategoriID,
                        principalTable: "Arbete Kategori",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Privat Frågor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Frågetext = table.Column<string>(name: "Fråge text", type: "nvarchar(max)", nullable: true),
                    kategoriID = table.Column<int>(name: "kategori ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privat Frågor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Privat Frågor_Privat kategori_kategori ID",
                        column: x => x.kategoriID,
                        principalTable: "Privat kategori",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Vanors Frågor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Frågetext = table.Column<string>(name: "Fråge text", type: "nvarchar(max)", nullable: true),
                    kategoriID = table.Column<int>(name: "kategori ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vanors Frågor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vanors Frågor_Vanors kategori_kategori ID",
                        column: x => x.kategoriID,
                        principalTable: "Vanors kategori",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Allmänt",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Befattningarbete = table.Column<string>(name: "Befattning/arbete", type: "nvarchar(max)", nullable: true),
                    Föddelsedatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ålder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kön = table.Column<int>(type: "int", nullable: false),
                    Viktkg = table.Column<double>(name: "Vikt/kg", type: "float", nullable: false),
                    Längd = table.Column<int>(type: "int", nullable: false),
                    Midjemått = table.Column<int>(type: "int", nullable: false),
                    Höftmått = table.Column<int>(type: "int", nullable: false),
                    Elitidrottare = table.Column<bool>(name: "Elitidrottare ", type: "bit", nullable: false),
                    Gravid = table.Column<bool>(name: "Gravid ", type: "bit", nullable: false),
                    Vegetarian = table.Column<bool>(type: "bit", nullable: false),
                    Diagnoser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kosttillskott = table.Column<string>(name: "Kosttillskott ", type: "nvarchar(max)", nullable: true),
                    Övrigaupplysningar = table.Column<string>(name: "Övriga upplysningar ", type: "nvarchar(max)", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allmänt", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Allmänt_Klient_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Klient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientMedicines",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    MedicineID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientMedicines", x => new { x.ClientID, x.MedicineID });
                    table.ForeignKey(
                        name: "FK_clientMedicines_Klient_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Klient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clientMedicines_Läkemedel_MedicineID",
                        column: x => x.MedicineID,
                        principalTable: "Läkemedel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arbete Svaror",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alternativtext = table.Column<string>(name: " Alternativ text", type: "nvarchar(max)", nullable: true),
                    Poäng = table.Column<double>(type: "float", nullable: false),
                    Stress = table.Column<bool>(type: "bit", nullable: false),
                    StyrkaBristID = table.Column<int>(name: "Styrka/Brist ID", type: "int", nullable: false),
                    StyrkaBristundergruppID = table.Column<int>(name: "Styrka/Brist under grupp ID", type: "int", nullable: false),
                    FrågeID = table.Column<int>(name: "Fråge ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbete Svaror", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Arbete Svaror_Arbete frågor_Fråge ID",
                        column: x => x.FrågeID,
                        principalTable: "Arbete frågor",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Arbete Svaror_Styrka-Brist Grupp_Styrka/Brist ID",
                        column: x => x.StyrkaBristID,
                        principalTable: "Styrka-Brist Grupp",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Arbete Svaror_Styrka-Brist under Grupp_Styrka/Brist under grupp ID",
                        column: x => x.StyrkaBristundergruppID,
                        principalTable: "Styrka-Brist under Grupp",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Privat Alternativ",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alternativtext = table.Column<string>(name: " Alternativ text", type: "nvarchar(max)", nullable: true),
                    Poäng = table.Column<double>(name: " Poäng", type: "float", nullable: false),
                    Stress = table.Column<bool>(type: "bit", nullable: false),
                    StyrkaBristgruppID = table.Column<int>(name: " Styrka/Brist grupp ID", type: "int", nullable: false),
                    StyrkaBristundergruppID = table.Column<int>(name: " Styrka/Brist under grupp ID", type: "int", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privat Alternativ", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Privat Alternativ_Privat Frågor_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Privat Frågor",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Privat Alternativ_Styrka-Brist Grupp_ Styrka/Brist grupp ID",
                        column: x => x.StyrkaBristgruppID,
                        principalTable: "Styrka-Brist Grupp",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Privat Alternativ_Styrka-Brist under Grupp_ Styrka/Brist under grupp ID",
                        column: x => x.StyrkaBristundergruppID,
                        principalTable: "Styrka-Brist under Grupp",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Vanors alternativ",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alternativtext = table.Column<string>(name: "Alternativ text", type: "nvarchar(max)", nullable: true),
                    Poäng = table.Column<double>(type: "float", nullable: false),
                    Stress = table.Column<bool>(type: "bit", nullable: false),
                    Subopt = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Nrmålsättnvitalitplan = table.Column<int>(name: "Nr målsättn vitalit.plan", type: "int", nullable: false),
                    rättelse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plusminusgrupp = table.Column<int>(name: "Plus-minus grupp", type: "int", nullable: false),
                    Undergrupp = table.Column<int>(type: "int", nullable: false),
                    FrågaID = table.Column<int>(name: "Fråga ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vanors alternativ", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vanors alternativ_Plus minus grupp_Plus-minus grupp",
                        column: x => x.Plusminusgrupp,
                        principalTable: "Plus minus grupp",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Vanors alternativ_Plus minus under grupp_Undergrupp",
                        column: x => x.Undergrupp,
                        principalTable: "Plus minus under grupp",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Vanors alternativ_Vanors Frågor_Fråga ID",
                        column: x => x.FrågaID,
                        principalTable: "Vanors Frågor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Program-Alternativ",
                columns: table => new
                {
                    AlternativID = table.Column<int>(name: "Alternativ ID", type: "int", nullable: false),
                    ProgramID = table.Column<int>(name: "Program ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program-Alternativ", x => new { x.AlternativID, x.ProgramID });
                    table.ForeignKey(
                        name: "FK_Program-Alternativ_programPlans_Program ID",
                        column: x => x.ProgramID,
                        principalTable: "programPlans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Program-Alternativ_Vanors alternativ_Alternativ ID",
                        column: x => x.AlternativID,
                        principalTable: "Vanors alternativ",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allmänt_ClientID",
                table: "Allmänt",
                column: "ClientID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Arbete frågor_Kategori ID",
                table: "Arbete frågor",
                column: "Kategori ID");

            migrationBuilder.CreateIndex(
                name: "IX_Arbete Kategori_Livs stil område",
                table: "Arbete Kategori",
                column: "Livs stil område",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Arbete Svaror_Fråge ID",
                table: "Arbete Svaror",
                column: "Fråge ID");

            migrationBuilder.CreateIndex(
                name: "IX_Arbete Svaror_Styrka/Brist ID",
                table: "Arbete Svaror",
                column: "Styrka/Brist ID");

            migrationBuilder.CreateIndex(
                name: "IX_Arbete Svaror_Styrka/Brist under grupp ID",
                table: "Arbete Svaror",
                column: "Styrka/Brist under grupp ID");

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
                name: "IX_clientMedicines_MedicineID",
                table: "clientMedicines",
                column: "MedicineID");

            migrationBuilder.CreateIndex(
                name: "IX_Klient_Rådgivare ID",
                table: "Klient",
                column: "Rådgivare ID");

            migrationBuilder.CreateIndex(
                name: "IX_Klient_UserID",
                table: "Klient",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plus minus under grupp_ Plus minus grupp ID",
                table: "Plus minus under grupp",
                column: " Plus minus grupp ID");

            migrationBuilder.CreateIndex(
                name: "IX_Privat Alternativ_ Styrka/Brist grupp ID",
                table: "Privat Alternativ",
                column: " Styrka/Brist grupp ID");

            migrationBuilder.CreateIndex(
                name: "IX_Privat Alternativ_ Styrka/Brist under grupp ID",
                table: "Privat Alternativ",
                column: " Styrka/Brist under grupp ID");

            migrationBuilder.CreateIndex(
                name: "IX_Privat Alternativ_QuestionID",
                table: "Privat Alternativ",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Privat Frågor_kategori ID",
                table: "Privat Frågor",
                column: "kategori ID");

            migrationBuilder.CreateIndex(
                name: "IX_Privat kategori_Livs stil område",
                table: "Privat kategori",
                column: "Livs stil område",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Program-Alternativ_Program ID",
                table: "Program-Alternativ",
                column: "Program ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rådgivare_UserID",
                table: "Rådgivare",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Styrka-Brist under Grupp_Styrka-Brist Grupp ID",
                table: "Styrka-Brist under Grupp",
                column: "Styrka-Brist Grupp ID");

            migrationBuilder.CreateIndex(
                name: "IX_Vanors alternativ_Fråga ID",
                table: "Vanors alternativ",
                column: "Fråga ID");

            migrationBuilder.CreateIndex(
                name: "IX_Vanors alternativ_Plus-minus grupp",
                table: "Vanors alternativ",
                column: "Plus-minus grupp");

            migrationBuilder.CreateIndex(
                name: "IX_Vanors alternativ_Undergrupp",
                table: "Vanors alternativ",
                column: "Undergrupp");

            migrationBuilder.CreateIndex(
                name: "IX_Vanors Frågor_kategori ID",
                table: "Vanors Frågor",
                column: "kategori ID");

            migrationBuilder.CreateIndex(
                name: "IX_Vanors kategori_Livs stil område",
                table: "Vanors kategori",
                column: "Livs stil område",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allmänt");

            migrationBuilder.DropTable(
                name: "Arbete Svaror");

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
                name: "clientMedicines");

            migrationBuilder.DropTable(
                name: "Privat Alternativ");

            migrationBuilder.DropTable(
                name: "Program-Alternativ");

            migrationBuilder.DropTable(
                name: "Arbete frågor");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "Läkemedel");

            migrationBuilder.DropTable(
                name: "Privat Frågor");

            migrationBuilder.DropTable(
                name: "Styrka-Brist under Grupp");

            migrationBuilder.DropTable(
                name: "programPlans");

            migrationBuilder.DropTable(
                name: "Vanors alternativ");

            migrationBuilder.DropTable(
                name: "Arbete Kategori");

            migrationBuilder.DropTable(
                name: "Rådgivare");

            migrationBuilder.DropTable(
                name: "Privat kategori");

            migrationBuilder.DropTable(
                name: "Styrka-Brist Grupp");

            migrationBuilder.DropTable(
                name: "Plus minus under grupp");

            migrationBuilder.DropTable(
                name: "Vanors Frågor");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Plus minus grupp");

            migrationBuilder.DropTable(
                name: "Vanors kategori");

            migrationBuilder.DropTable(
                name: "Livs stil område");
        }
    }
}
