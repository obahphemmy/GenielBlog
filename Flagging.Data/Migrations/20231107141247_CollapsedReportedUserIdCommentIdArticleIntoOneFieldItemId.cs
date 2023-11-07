using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Flagging.Data.Migrations
{
    /// <inheritdoc />
    public partial class CollapsedReportedUserIdCommentIdArticleIntoOneFieldItemId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flags_Articles_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flags_Comments_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flags_Users_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Tracy", "Williamson" },
                    { 2, "Mariane", "Fritsch" },
                    { 3, "Haleigh", "Pouros" },
                    { 4, "Marilou", "Emard" },
                    { 5, "Luther", "Fritsch" },
                    { 6, "Hyman", "Harris" },
                    { 7, "German", "Bauch" },
                    { 8, "Emily", "Armstrong" },
                    { 9, "Candelario", "Schoen" },
                    { 10, "Michale", "Purdy" },
                    { 11, "Marco", "Spinka" },
                    { 12, "Carlee", "O'Keefe" },
                    { 13, "Keith", "Brakus" },
                    { 14, "Kale", "Hackett" },
                    { 15, "Keyon", "Rath" },
                    { 16, "Celestino", "Reilly" },
                    { 17, "Felipe", "Macejkovic" },
                    { 18, "Rose", "Treutel" },
                    { 19, "Easter", "Raynor" },
                    { 20, "Cyrus", "Jacobi" },
                    { 21, "Delores", "Brekke" },
                    { 22, "Damien", "Gislason" },
                    { 23, "Aleen", "Botsford" },
                    { 24, "Carlotta", "D'Amore" },
                    { 25, "Berenice", "Blick" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleId", "Description", "UserId" },
                values: new object[,]
                {
                    { 1, null, "Dolor totam minus eum ab recusandae autem id aut. Suscipit quia nesciunt ducimus officia consequatur repellat molestiae quia neque. Qui molestiae et voluptas sunt error. Cumque ipsam accusamus consequatur ut occaecati quod at. Animi eaque reprehenderit ut. Omnis sequi est et. Laudantium ea non perspiciatis unde autem. Similique repudiandae accusantium mollitia voluptas est.", 1 },
                    { 2, null, "Odit ducimus laboriosam deleniti in laudantium. Et sint id in id esse sit aut. Excepturi aut perferendis commodi est delectus expedita alias. Recusandae sit sed corrupti quod. Id voluptas similique reprehenderit autem quos ratione unde.", 2 },
                    { 3, null, "Dolores sint necessitatibus ratione unde voluptatem sunt magni. Illum autem saepe ut qui voluptas qui fugit deleniti velit. Voluptatem nulla perferendis occaecati maxime voluptatem earum facilis corporis. Saepe neque eius at sed aut at corrupti tempore. Error nihil et magni pariatur quibusdam. Sunt dignissimos ex sed aut perferendis itaque hic qui. Commodi cupiditate aliquid et. Dolorum asperiores magni delectus quia praesentium asperiores.", 3 },
                    { 4, null, "Eos et et et quis soluta ut blanditiis expedita. Odio et totam culpa. Commodi optio saepe ipsum rerum velit in. Iusto rerum corrupti ut autem repudiandae fuga libero. Officia et incidunt et qui cupiditate qui. Nemo et tenetur et.", 4 },
                    { 5, null, "Facilis atque numquam aut commodi debitis. Praesentium excepturi eligendi tenetur quam est qui architecto hic ut. Aliquid temporibus at repellat iste rerum voluptatum modi tempore unde. Voluptatibus minima libero est asperiores omnis tenetur ut mollitia. Eveniet est ea eum in.", 5 },
                    { 6, null, "Enim voluptatem qui quo voluptatem consequatur. Et iste odio vel. Blanditiis et sapiente cumque laborum ea qui ut id. Illum neque occaecati laborum eum quas qui corporis numquam vel. Ut autem magnam omnis cumque. At consequuntur quia veniam qui sed. Et quaerat adipisci et et quae qui. Adipisci qui omnis amet possimus.", 6 },
                    { 7, null, "Consectetur provident nobis aut commodi provident nulla tempora aut. Minima fugit minus consequatur quis est eveniet expedita rerum. Aut eius autem et. Ratione vitae consequatur eos expedita veniam minus illo ut nobis. Et corporis itaque nulla asperiores laboriosam reprehenderit. Et in beatae rerum aspernatur.", 7 },
                    { 8, null, "Recusandae et aliquid quo rerum reiciendis voluptas natus amet qui. Veritatis et quaerat illum mollitia. Quae consectetur voluptatum natus quis sequi illo id alias. Qui excepturi aliquam eveniet cupiditate. Ut impedit consequatur est.", 8 },
                    { 9, null, "Non sunt sed sit reiciendis quia et officia architecto et. Doloribus voluptatum cupiditate qui labore odit eius ducimus. Ratione itaque sapiente est odio ab. Voluptatibus qui iure dignissimos rerum sit aut sequi. Eos commodi in labore molestiae qui sed.", 9 },
                    { 10, null, "Repudiandae amet quaerat quo sed accusantium corrupti autem dolor. Harum consequatur consequatur velit. Aut inventore sit occaecati distinctio hic ex est soluta. Impedit et ut adipisci corrupti cum. Id rerum alias aut. Voluptates nesciunt voluptas odit minus et unde dolorum. Accusantium iste quas eveniet voluptates ea eum vel dolores.", 10 },
                    { 11, null, "Possimus illum et eos quasi. Eius sint ipsa sint dignissimos qui consequatur beatae veniam. Voluptatum amet maxime laudantium fuga voluptatem inventore mollitia. At nihil unde et aut porro fugiat fugit ut voluptatem. Aut consequatur rerum dolores est repellendus nulla aut.", 11 },
                    { 12, null, "Voluptates ut eveniet nam sed iste. Dolor enim reprehenderit quis cupiditate omnis eos. Porro et ut odit et dolores. Est aut impedit dolores eum soluta deserunt aliquid. Quos totam facere debitis fugit. Voluptatibus dolor rerum deleniti sint corporis voluptatum sunt ut.", 12 },
                    { 13, null, "Esse nostrum qui dolores expedita ipsa aspernatur omnis. Ea ea quaerat sunt qui odio sed mollitia. Dicta possimus quam officia odio pariatur quasi aut ullam. Ut quia vitae voluptas enim ut et. Itaque dolorem nesciunt sed non quasi. Est molestias dicta culpa odit qui eaque itaque inventore.", 13 },
                    { 14, null, "Sapiente aut cum sint iusto aliquam doloribus modi. Velit ea architecto eveniet. Non molestiae delectus aut nulla cupiditate vitae quia. Voluptatem rerum vel rerum consectetur sequi. Consequatur repellendus porro omnis. Autem doloremque eius quod. Amet a et beatae non qui repellat.", 14 },
                    { 15, null, "Placeat eos eveniet rerum laboriosam. Qui corporis architecto assumenda nostrum dolorem omnis. Ea aliquam quam eveniet perferendis aut sit. Alias quo explicabo nulla. Est nobis explicabo non voluptatem cumque quod omnis consequuntur voluptas. Culpa ea ut est aut aut incidunt id et ipsa. Aliquam atque expedita adipisci occaecati rerum animi. Reprehenderit hic qui assumenda perferendis.", 15 },
                    { 16, null, "Aut tempora deleniti provident tenetur illum tempore hic fugit laborum. Error ea totam voluptatem asperiores deserunt. Illum velit veniam necessitatibus impedit est atque possimus. Nisi ducimus fugiat rem quo id ab similique architecto velit. Quas aut tempore ex maxime ea ut vero. Et amet exercitationem aut sed perferendis doloremque mollitia voluptatem.", 16 },
                    { 17, null, "Quos cupiditate eos magni sit dicta incidunt totam. Qui sit eius et odio ipsam cupiditate odio. Reprehenderit mollitia deserunt quis illo rerum est facilis aperiam quam. Voluptas voluptatibus et voluptas excepturi. Quia animi delectus dolorum. Reprehenderit et harum cum qui quaerat soluta ab quas consequatur. Iusto sit eos tenetur ut aut id debitis ut quidem. Quod necessitatibus sunt voluptatem vel quas quasi inventore deleniti non.", 17 },
                    { 18, null, "Est nihil quas voluptas nostrum velit perspiciatis autem neque. Aut aut iste ab voluptas corrupti. Blanditiis velit quos hic facilis voluptatibus suscipit illo. Totam dolor minus incidunt aut dolor velit molestias ipsa debitis. Et impedit itaque qui nam placeat facilis consequatur laborum unde. Et dolore illum alias est eos maxime. Voluptatum sed vel at laborum quas iure deleniti.", 18 },
                    { 19, null, "Et enim placeat distinctio. Aut eaque et non. Non natus expedita qui aut explicabo quia dolores. Id quo hic est molestias sint necessitatibus maxime cumque modi. Eveniet fuga expedita reiciendis debitis repellat laudantium voluptatum.", 19 },
                    { 20, null, "Doloribus ipsum mollitia consectetur qui cumque exercitationem ab. Ex aliquam eius quos occaecati unde ut repellendus accusantium aut. Omnis quas aperiam vel vel repellat provident. Sit quis accusamus qui libero amet dignissimos praesentium cupiditate maiores. Qui fuga minima qui porro temporibus ut impedit consequatur et.", 20 },
                    { 21, null, "Doloremque reiciendis explicabo dolores. Incidunt sit hic delectus ea facilis non praesentium cupiditate laborum. Error rerum at sit dolores reprehenderit rerum sit. Omnis ex deleniti sit laboriosam modi explicabo enim omnis sint. Quia nostrum necessitatibus assumenda quis ut quo saepe vero ut. Dolores quisquam voluptatem aut ut quis et eum. Facilis dolores incidunt enim nihil non deserunt. Laborum ipsum sint quia consequatur nihil et dolores.", 21 },
                    { 22, null, "Quam dolore dolores ipsam molestiae ut error eaque. Minus voluptas consequuntur fugit magni eos. Quo et ut voluptas et laborum odio autem. Hic ut consequatur suscipit sed. Quo non occaecati labore eveniet ut aliquid alias sint dignissimos. Dolorem magni et veniam ab qui molestiae harum tempora.", 22 },
                    { 23, null, "Dolorum similique temporibus aliquid et. Omnis porro dignissimos qui quaerat impedit quam. Dolore illo quia voluptas. Et est molestiae quibusdam magnam earum et dolores similique. Corporis ab ea eaque quod. Praesentium hic molestiae voluptatem cupiditate qui dolorum aliquid animi blanditiis. Eius nulla eaque placeat modi perferendis voluptatem et et.", 23 },
                    { 24, null, "Nihil repellendus perspiciatis corporis et provident et sapiente est delectus. Voluptates animi similique sit. In voluptates in ab quaerat et illo possimus. Aut adipisci omnis est quam. Aliquid alias voluptatem distinctio deserunt odio temporibus facilis veritatis.", 24 },
                    { 25, null, "Mollitia omnis incidunt officia porro in quam et. Blanditiis facere numquam eos tempora. Quibusdam quia a qui autem ab deserunt ea. Quo est omnis consequatur et et sapiente culpa doloribus omnis. Eum minus quaerat autem ratione.", 25 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Message", "UserId" },
                values: new object[,]
                {
                    { 1, "Maxime aut dolor eos possimus officia ea sed corporis.", 1 },
                    { 2, "Voluptates quasi corrupti velit consequuntur.", 2 },
                    { 3, "A quis et id sapiente.", 3 },
                    { 4, "Doloremque et enim enim harum eos natus sapiente dolor in.", 4 },
                    { 5, "Id rem vero eos recusandae.", 5 },
                    { 6, "Et dolore dolor vel quia in ut quos.", 6 },
                    { 7, "Eos et necessitatibus magni incidunt libero.", 7 },
                    { 8, "Id optio enim quasi voluptatibus ea quos laudantium vel velit placeat.", 8 },
                    { 9, "Animi et et qui qui.", 9 },
                    { 10, "Facilis reprehenderit odit ipsam consectetur cupiditate.", 10 },
                    { 11, "Impedit error facilis autem occaecati eos ut occaecati expedita.", 11 },
                    { 12, "Eius error esse vel aut accusantium.", 12 },
                    { 13, "Aut reiciendis sit voluptas aut aspernatur et quae.", 13 },
                    { 14, "Rerum cumque aut illum harum recusandae.", 14 },
                    { 15, "Ut praesentium sit est minus.", 15 },
                    { 16, "Tenetur ipsa fugit tenetur animi id id.", 16 },
                    { 17, "Vel maxime tempore consequatur sed.", 17 },
                    { 18, "Ad harum iste et odio quam nam alias aut doloribus.", 18 },
                    { 19, "Sit ducimus repellat voluptatem assumenda nihil aut quia nihil.", 19 },
                    { 20, "Aut sit velit in pariatur aut nihil ut provident expedita et.", 20 },
                    { 21, "Quam nisi nobis velit similique ut neque dolor quia.", 21 },
                    { 22, "Aut in et quis ea nesciunt earum tempore tenetur est omnis.", 22 },
                    { 23, "Iste similique magni et quos et ea harum.", 23 },
                    { 24, "Rem perferendis corrupti vel deserunt.", 24 },
                    { 25, "Ipsa mollitia excepturi aliquid voluptates itaque error est illo et.", 25 }
                });

            migrationBuilder.InsertData(
                table: "Flags",
                columns: new[] { "Id", "DateCreated", "ItemId", "Status", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(1981, 10, 27, 0, 0, 0, 0, DateTimeKind.Utc), 1, 0, 0 },
                    { 2, new DateTime(1929, 10, 2, 0, 0, 0, 0, DateTimeKind.Utc), 1, 0, 0 },
                    { 3, new DateTime(1961, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), 2, 0, 0 },
                    { 4, new DateTime(1979, 4, 11, 0, 0, 0, 0, DateTimeKind.Utc), 2, 0, 0 },
                    { 5, new DateTime(1983, 8, 27, 0, 0, 0, 0, DateTimeKind.Utc), 2, 0, 0 },
                    { 6, new DateTime(1920, 6, 4, 0, 0, 0, 0, DateTimeKind.Utc), 4, 0, 0 },
                    { 7, new DateTime(2002, 3, 6, 0, 0, 0, 0, DateTimeKind.Utc), 4, 0, 0 },
                    { 8, new DateTime(1925, 3, 26, 0, 0, 0, 0, DateTimeKind.Utc), 4, 0, 0 },
                    { 9, new DateTime(1927, 3, 27, 0, 0, 0, 0, DateTimeKind.Utc), 4, 0, 0 },
                    { 10, new DateTime(1972, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, 0, 0 },
                    { 11, new DateTime(1924, 3, 8, 0, 0, 0, 0, DateTimeKind.Utc), 5, 0, 0 },
                    { 12, new DateTime(1961, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), 6, 0, 0 },
                    { 13, new DateTime(1968, 9, 13, 0, 0, 0, 0, DateTimeKind.Utc), 6, 0, 0 },
                    { 14, new DateTime(1933, 10, 31, 0, 0, 0, 0, DateTimeKind.Utc), 7, 0, 0 },
                    { 15, new DateTime(1982, 10, 6, 0, 0, 0, 0, DateTimeKind.Utc), 9, 0, 0 },
                    { 16, new DateTime(1964, 8, 13, 0, 0, 0, 0, DateTimeKind.Utc), 9, 0, 0 },
                    { 17, new DateTime(1931, 3, 28, 0, 0, 0, 0, DateTimeKind.Utc), 10, 0, 0 },
                    { 18, new DateTime(1912, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), 10, 0, 0 },
                    { 19, new DateTime(1927, 6, 7, 0, 0, 0, 0, DateTimeKind.Utc), 11, 0, 0 },
                    { 20, new DateTime(1982, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), 12, 0, 0 },
                    { 21, new DateTime(1975, 6, 16, 0, 0, 0, 0, DateTimeKind.Utc), 13, 0, 0 },
                    { 22, new DateTime(1980, 2, 29, 0, 0, 0, 0, DateTimeKind.Utc), 13, 0, 0 },
                    { 23, new DateTime(2004, 2, 12, 0, 0, 0, 0, DateTimeKind.Utc), 14, 0, 0 },
                    { 24, new DateTime(2015, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), 14, 0, 0 },
                    { 25, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Utc), 15, 0, 0 },
                    { 26, new DateTime(1928, 9, 13, 0, 0, 0, 0, DateTimeKind.Utc), 16, 0, 0 },
                    { 27, new DateTime(1938, 7, 12, 0, 0, 0, 0, DateTimeKind.Utc), 17, 0, 0 },
                    { 28, new DateTime(1938, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc), 17, 0, 0 },
                    { 29, new DateTime(1974, 6, 2, 0, 0, 0, 0, DateTimeKind.Utc), 19, 0, 0 },
                    { 30, new DateTime(1962, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 19, 0, 0 },
                    { 31, new DateTime(1964, 6, 19, 0, 0, 0, 0, DateTimeKind.Utc), 19, 0, 0 },
                    { 32, new DateTime(1966, 4, 24, 0, 0, 0, 0, DateTimeKind.Utc), 20, 0, 0 },
                    { 33, new DateTime(1903, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), 21, 0, 0 },
                    { 34, new DateTime(1912, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), 21, 0, 0 },
                    { 35, new DateTime(1963, 4, 3, 0, 0, 0, 0, DateTimeKind.Utc), 22, 0, 0 },
                    { 36, new DateTime(1962, 7, 15, 0, 0, 0, 0, DateTimeKind.Utc), 23, 0, 0 },
                    { 37, new DateTime(1962, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc), 24, 0, 0 },
                    { 38, new DateTime(1971, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc), 24, 0, 0 },
                    { 39, new DateTime(2004, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), 24, 0, 0 },
                    { 40, new DateTime(2007, 9, 7, 0, 0, 0, 0, DateTimeKind.Utc), 1, 0, 2 },
                    { 41, new DateTime(1970, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), 1, 0, 2 },
                    { 42, new DateTime(1936, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), 2, 0, 2 },
                    { 43, new DateTime(1950, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), 3, 0, 2 },
                    { 44, new DateTime(1969, 4, 20, 0, 0, 0, 0, DateTimeKind.Utc), 4, 0, 2 },
                    { 45, new DateTime(1954, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), 5, 0, 2 },
                    { 46, new DateTime(1981, 12, 18, 0, 0, 0, 0, DateTimeKind.Utc), 5, 0, 2 },
                    { 47, new DateTime(1956, 2, 25, 0, 0, 0, 0, DateTimeKind.Utc), 5, 0, 2 },
                    { 48, new DateTime(1925, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), 6, 0, 2 },
                    { 49, new DateTime(1971, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), 6, 0, 2 },
                    { 50, new DateTime(1967, 5, 18, 0, 0, 0, 0, DateTimeKind.Utc), 7, 0, 2 },
                    { 51, new DateTime(2018, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), 8, 0, 2 },
                    { 52, new DateTime(2010, 3, 7, 0, 0, 0, 0, DateTimeKind.Utc), 10, 0, 2 },
                    { 53, new DateTime(1958, 4, 22, 0, 0, 0, 0, DateTimeKind.Utc), 10, 0, 2 },
                    { 54, new DateTime(1953, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), 11, 0, 2 },
                    { 55, new DateTime(1951, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), 12, 0, 2 },
                    { 56, new DateTime(1962, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), 13, 0, 2 },
                    { 57, new DateTime(1992, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), 13, 0, 2 },
                    { 58, new DateTime(1958, 7, 30, 0, 0, 0, 0, DateTimeKind.Utc), 16, 0, 2 },
                    { 59, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), 17, 0, 2 },
                    { 60, new DateTime(2014, 9, 4, 0, 0, 0, 0, DateTimeKind.Utc), 17, 0, 2 },
                    { 61, new DateTime(2007, 6, 7, 0, 0, 0, 0, DateTimeKind.Utc), 17, 0, 2 },
                    { 62, new DateTime(1994, 6, 11, 0, 0, 0, 0, DateTimeKind.Utc), 18, 0, 2 },
                    { 63, new DateTime(1983, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 19, 0, 2 },
                    { 64, new DateTime(1921, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc), 19, 0, 2 },
                    { 65, new DateTime(2004, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), 19, 0, 2 },
                    { 66, new DateTime(1994, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), 19, 0, 2 },
                    { 67, new DateTime(1951, 4, 17, 0, 0, 0, 0, DateTimeKind.Utc), 19, 0, 2 },
                    { 68, new DateTime(1942, 6, 27, 0, 0, 0, 0, DateTimeKind.Utc), 21, 0, 2 },
                    { 69, new DateTime(1960, 6, 21, 0, 0, 0, 0, DateTimeKind.Utc), 23, 0, 2 },
                    { 70, new DateTime(2012, 12, 15, 0, 0, 0, 0, DateTimeKind.Utc), 23, 0, 2 },
                    { 71, new DateTime(1976, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23, 0, 2 },
                    { 72, new DateTime(1935, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), 25, 0, 2 },
                    { 73, new DateTime(1943, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), 1, 0, 1 },
                    { 74, new DateTime(1949, 10, 8, 0, 0, 0, 0, DateTimeKind.Utc), 2, 0, 1 },
                    { 75, new DateTime(2023, 7, 31, 0, 0, 0, 0, DateTimeKind.Utc), 2, 0, 1 },
                    { 76, new DateTime(1916, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), 3, 0, 1 },
                    { 77, new DateTime(1962, 10, 29, 0, 0, 0, 0, DateTimeKind.Utc), 5, 0, 1 },
                    { 78, new DateTime(1962, 3, 8, 0, 0, 0, 0, DateTimeKind.Utc), 6, 0, 1 },
                    { 79, new DateTime(1982, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), 6, 0, 1 },
                    { 80, new DateTime(1975, 4, 17, 0, 0, 0, 0, DateTimeKind.Utc), 6, 0, 1 },
                    { 81, new DateTime(1998, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc), 7, 0, 1 },
                    { 82, new DateTime(1977, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), 7, 0, 1 },
                    { 83, new DateTime(1962, 7, 30, 0, 0, 0, 0, DateTimeKind.Utc), 8, 0, 1 },
                    { 84, new DateTime(1904, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc), 8, 0, 1 },
                    { 85, new DateTime(1998, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), 8, 0, 1 },
                    { 86, new DateTime(1961, 11, 9, 0, 0, 0, 0, DateTimeKind.Utc), 9, 0, 1 },
                    { 87, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), 9, 0, 1 },
                    { 88, new DateTime(2013, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), 9, 0, 1 },
                    { 89, new DateTime(1934, 7, 24, 0, 0, 0, 0, DateTimeKind.Utc), 9, 0, 1 },
                    { 90, new DateTime(1943, 1, 19, 0, 0, 0, 0, DateTimeKind.Utc), 10, 0, 1 },
                    { 91, new DateTime(1952, 8, 28, 0, 0, 0, 0, DateTimeKind.Utc), 11, 0, 1 },
                    { 92, new DateTime(1966, 7, 25, 0, 0, 0, 0, DateTimeKind.Utc), 11, 0, 1 },
                    { 93, new DateTime(2001, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), 11, 0, 1 },
                    { 94, new DateTime(1955, 11, 5, 0, 0, 0, 0, DateTimeKind.Utc), 12, 0, 1 },
                    { 95, new DateTime(1941, 7, 24, 0, 0, 0, 0, DateTimeKind.Utc), 14, 0, 1 },
                    { 96, new DateTime(1972, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), 14, 0, 1 },
                    { 97, new DateTime(1962, 4, 3, 0, 0, 0, 0, DateTimeKind.Utc), 15, 0, 1 },
                    { 98, new DateTime(1983, 9, 22, 0, 0, 0, 0, DateTimeKind.Utc), 16, 0, 1 },
                    { 99, new DateTime(1962, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), 16, 0, 1 },
                    { 100, new DateTime(1977, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), 17, 0, 1 },
                    { 101, new DateTime(2017, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), 17, 0, 1 },
                    { 102, new DateTime(1949, 2, 21, 0, 0, 0, 0, DateTimeKind.Utc), 17, 0, 1 },
                    { 103, new DateTime(1962, 2, 25, 0, 0, 0, 0, DateTimeKind.Utc), 18, 0, 1 },
                    { 104, new DateTime(2006, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc), 18, 0, 1 },
                    { 105, new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Utc), 18, 0, 1 },
                    { 106, new DateTime(1958, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), 19, 0, 1 },
                    { 107, new DateTime(2001, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), 19, 0, 1 },
                    { 108, new DateTime(2013, 6, 7, 0, 0, 0, 0, DateTimeKind.Utc), 20, 0, 1 },
                    { 109, new DateTime(1961, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 20, 0, 1 },
                    { 110, new DateTime(1916, 6, 7, 0, 0, 0, 0, DateTimeKind.Utc), 20, 0, 1 },
                    { 111, new DateTime(1925, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), 22, 0, 1 },
                    { 112, new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), 22, 0, 1 },
                    { 113, new DateTime(1946, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc), 23, 0, 1 },
                    { 114, new DateTime(1995, 10, 27, 0, 0, 0, 0, DateTimeKind.Utc), 23, 0, 1 },
                    { 115, new DateTime(1925, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23, 0, 1 },
                    { 116, new DateTime(1986, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc), 23, 0, 1 },
                    { 117, new DateTime(1966, 10, 22, 0, 0, 0, 0, DateTimeKind.Utc), 23, 0, 1 },
                    { 118, new DateTime(1923, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), 24, 0, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleId",
                table: "Articles",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Flags_ItemId",
                table: "Flags",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flags");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
