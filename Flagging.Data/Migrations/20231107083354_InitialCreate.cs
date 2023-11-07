using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Flagging.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    ReportedUserId = table.Column<int>(type: "int", nullable: true),
                    ArticleId = table.Column<int>(type: "int", nullable: true),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flags_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flags_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flags_Users_ReportedUserId",
                        column: x => x.ReportedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Linda", "Swift" },
                    { 2, "Thora", "Welch" },
                    { 3, "Trevor", "Lang" },
                    { 4, "Lew", "Grady" },
                    { 5, "Jarred", "Waelchi" },
                    { 6, "Marianna", "Swaniawski" },
                    { 7, "Noemie", "Corkery" },
                    { 8, "Dillan", "Gottlieb" },
                    { 9, "Vida", "Stamm" },
                    { 10, "Jasmin", "Bednar" },
                    { 11, "Hallie", "Boehm" },
                    { 12, "Darrel", "Streich" },
                    { 13, "Margarett", "Fisher" },
                    { 14, "Patience", "Mraz" },
                    { 15, "Ken", "Collins" },
                    { 16, "Joannie", "Abernathy" },
                    { 17, "Keenan", "Klocko" },
                    { 18, "Herman", "Towne" },
                    { 19, "Oda", "Greenholt" },
                    { 20, "Marlen", "Ebert" },
                    { 21, "Pearlie", "Barton" },
                    { 22, "Amos", "Haley" },
                    { 23, "Markus", "Bartell" },
                    { 24, "Brady", "Heller" },
                    { 25, "Theodore", "Rohan" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleId", "Description", "UserId" },
                values: new object[,]
                {
                    { 1, null, "Libero facilis aspernatur enim blanditiis. Aut eos impedit voluptatem placeat provident. Qui quo doloremque illo porro omnis cupiditate facilis consectetur. Et reprehenderit pariatur perferendis distinctio voluptas enim iste neque eos. Alias possimus id deserunt perferendis. Quisquam ea ut est maiores. Consequuntur voluptatem et delectus est nemo rerum natus. Illum accusamus ipsum odit voluptas.", 1 },
                    { 2, null, "Consequatur sunt velit nihil possimus cupiditate deleniti harum. Laboriosam nobis quis minus qui blanditiis. Dolore quae deleniti cum sit illum quidem eveniet. Dolor aut et et fugiat. Earum consequatur nam a quo quia quia id. Veniam sed rerum quasi accusamus explicabo consequatur temporibus voluptatem. Ullam eligendi quae suscipit amet.", 2 },
                    { 3, null, "Magnam vitae repellat soluta facere repudiandae ducimus deleniti iure. Ducimus tempore velit ut. Quas maxime exercitationem ut voluptas in vero illo dolorem. Beatae et et quidem quis corrupti nemo ea qui. Dolor sit est et sapiente. Et nulla voluptatum placeat perspiciatis voluptas similique debitis. Unde minus enim cupiditate aut.", 3 },
                    { 4, null, "Dolor non autem autem molestias pariatur commodi placeat. Nulla corrupti quo saepe. Dolor aspernatur harum aut amet aliquid. Dolor beatae veniam quia voluptas in provident enim vero. Sed et debitis optio repellendus reiciendis maiores aut velit. Exercitationem animi molestias voluptatibus ut voluptas deleniti distinctio facere.", 4 },
                    { 5, null, "Eligendi fugiat perferendis quibusdam. Exercitationem velit beatae ea. Praesentium alias blanditiis ad culpa minima nemo dignissimos optio voluptas. In quia quae inventore quam omnis est. Nostrum rerum facilis repellendus ad molestiae. Soluta qui ut consequuntur sint qui recusandae eum et. Et sed et sint. Et voluptas enim voluptas non.", 5 },
                    { 6, null, "Ipsa nobis eius dolorem quo vero rem. Ipsum id ea rerum officiis velit perspiciatis aut. Quam saepe sunt dolores ea. Fugiat qui ullam consequatur consequatur cupiditate rerum perspiciatis eum soluta. Sit quia nemo maxime in aliquam sint officiis molestiae consequatur. Expedita sit qui et dolorem dolorem ut nobis.", 6 },
                    { 7, null, "Nam dolore illo voluptatibus omnis recusandae aut unde. Enim omnis autem quia architecto at et. Reiciendis rem et voluptas exercitationem autem nisi vitae vero. Quo rerum corporis rerum deleniti ut. Tempore temporibus nihil ullam. Ea architecto non porro reprehenderit est. Voluptates maiores similique voluptas nihil. Voluptatem distinctio maxime corrupti.", 7 },
                    { 8, null, "Consequatur neque ea nostrum. Eum est laudantium rerum nihil sit optio quasi rerum nihil. Laboriosam excepturi ipsum qui eos veniam nostrum non. Est itaque quae magnam et culpa. Perspiciatis natus voluptas dolores eum sit. Laboriosam at repellendus aut qui necessitatibus aut.", 8 },
                    { 9, null, "Doloremque voluptas repudiandae alias dolorem. Voluptatem ut eligendi est in est dolorem. Blanditiis autem quia quidem mollitia voluptatem doloribus cumque et dolor. Est error cumque dicta debitis repudiandae necessitatibus alias porro cumque. Consequatur ut nam eligendi eos consequatur et quisquam.", 9 },
                    { 10, null, "Quaerat maiores eum et temporibus blanditiis quidem sed similique corrupti. Porro nesciunt voluptas porro autem autem dolor cumque ea quod. Voluptatem maxime illo quidem velit accusamus quia dolorem dolorum. Esse corrupti quis ut. Qui dolor unde fuga officia modi ut nihil. Esse voluptas vel voluptatem qui aperiam voluptatem placeat consequatur dolores.", 10 },
                    { 11, null, "Enim soluta ut amet voluptas cum qui saepe quo cupiditate. Sunt a illum est vitae rerum dolore tempore voluptatem autem. Mollitia repellat accusantium vitae suscipit. Quia sequi dolores earum qui. Magnam vel magnam itaque. Sed ut tempora quis.", 11 },
                    { 12, null, "Voluptas et est soluta eveniet aut nobis. Recusandae fugit consequatur ab. Consequatur et quidem et ipsa saepe aut. Ipsam expedita sequi inventore aliquam similique assumenda fugiat inventore. Quidem laborum ipsum reiciendis omnis voluptate porro animi. Qui pariatur quasi tenetur eum qui sequi voluptatem culpa. Hic rem veritatis quod dolores omnis. Dolorem accusantium omnis eum et ipsum.", 12 },
                    { 13, null, "Doloremque sit eum nisi molestias recusandae laboriosam omnis. Similique debitis doloremque quis in non et. Eum ipsa sed suscipit repellat. Aut iste exercitationem harum. Tempore quo quaerat incidunt rem et ratione porro dolorum. Earum perferendis deleniti suscipit soluta exercitationem dolor aliquid ut consectetur. Qui non ipsum repellat. Deleniti quia iure quis et veritatis.", 13 },
                    { 14, null, "Excepturi amet pariatur eveniet. Velit nulla autem voluptatem aperiam sint mollitia eum sit vero. Tempora facere nobis corrupti optio est facere eaque. Qui qui sequi in non ut. Eveniet maxime alias similique a nobis corporis consequatur omnis aperiam.", 14 },
                    { 15, null, "Debitis est ea et asperiores aliquid dolor. Esse ut dolor quisquam ipsa quam est assumenda aut. Ex voluptas provident beatae rerum minima sit reiciendis ut cupiditate. Quam reiciendis vitae impedit odio accusantium ipsa quo. Iure deserunt corrupti inventore voluptates quod officia accusamus beatae aut. Odit nesciunt aut cupiditate. Ea eum dolorum aut qui eligendi consequuntur.", 15 },
                    { 16, null, "Ut doloremque quia culpa tempore. Tenetur soluta voluptate ad. Magnam cupiditate labore ut id delectus libero accusantium. Et qui consequatur non natus inventore. Placeat consequatur voluptates repellat.", 16 },
                    { 17, null, "Ullam unde nulla autem sapiente expedita. Mollitia atque et quod eius modi et hic maiores. Quibusdam sunt laboriosam ut earum nostrum temporibus repellendus dicta. Qui voluptatibus commodi in aut voluptatem maiores autem. Ut quidem sint quod sint et.", 17 },
                    { 18, null, "Beatae voluptatem omnis vitae repellendus dignissimos molestiae omnis amet et. Non vero quod ratione exercitationem placeat a illo adipisci nihil. Eaque eos eos aut dicta et. Deserunt ea debitis eos iusto ullam adipisci eos optio qui. Illo atque mollitia cum ex qui error repellendus.", 18 },
                    { 19, null, "Nulla sapiente velit excepturi iusto. Commodi accusamus veniam fugiat sed est nesciunt dolorem deserunt. Et incidunt ipsam molestias exercitationem. Molestias deleniti veritatis autem minus nisi qui quia. Placeat adipisci minima mollitia labore cupiditate. Voluptatem rem beatae perspiciatis optio itaque accusamus. Laudantium quos amet quia non. A tenetur cum dicta illo quaerat et itaque.", 19 },
                    { 20, null, "A exercitationem et consequuntur quia. Non qui aut perspiciatis placeat aut corrupti quo cumque. Quia occaecati dolores fuga. Necessitatibus accusamus occaecati ducimus illum sequi ab esse. Vel perspiciatis voluptatum fugit aliquid in. Molestias excepturi consequatur provident quae consequatur totam.", 20 },
                    { 21, null, "Debitis ipsam optio atque voluptatibus nisi. Et aliquam perspiciatis facilis corrupti nemo et eius. Quis nobis repellat aperiam. Eum doloremque nulla mollitia harum suscipit voluptate occaecati. Repellat voluptate asperiores maiores non praesentium perferendis aut. Quos soluta illo deserunt vitae. Asperiores neque temporibus totam et aperiam perspiciatis odio.", 21 },
                    { 22, null, "Hic temporibus sequi occaecati deleniti eos. Iure sit ipsum ullam. Dolores et illo perspiciatis reprehenderit perferendis aut consequuntur magni aspernatur. Tenetur aut a repellat soluta. Consequatur corporis delectus ut praesentium. Dicta non voluptas voluptatibus recusandae aut aspernatur a est nemo.", 22 },
                    { 23, null, "Quasi similique aut beatae quaerat officia explicabo. Inventore magni nemo repellat architecto ut et doloremque illo similique. Quia non quidem rerum et omnis veniam provident vero ad. Perferendis sit consequatur blanditiis. Inventore ea id molestias cumque placeat illo. Impedit aut qui sit harum sunt voluptates consequatur nisi. Ut recusandae possimus incidunt pariatur corrupti aut voluptate recusandae doloremque.", 23 },
                    { 24, null, "Ipsa nam quis rerum quam aspernatur exercitationem qui dicta dolor. Odit dolore voluptas nostrum beatae aut neque nobis suscipit qui. Quia laboriosam possimus voluptatem temporibus ut nobis est deleniti corrupti. Est ex sit voluptatem fugit dolorem sit nemo debitis. Voluptatibus sint repudiandae velit debitis vel beatae. Error reprehenderit iste soluta quo debitis delectus. Quos repellendus rerum eaque in eius aut rerum sit sed.", 24 },
                    { 25, null, "Nihil veritatis a et eveniet. Reiciendis dignissimos ad aliquid rerum praesentium architecto. Impedit sed et quisquam doloribus. Sit iusto optio sapiente. Ipsam quidem eos harum qui nisi alias aliquid quasi.", 25 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Message", "UserId" },
                values: new object[,]
                {
                    { 1, "Fugiat repellendus ut rem et animi et sapiente rerum expedita ipsa.", 1 },
                    { 2, "Quasi minima consequuntur reiciendis quidem nam aut nisi expedita.", 2 },
                    { 3, "Odit aut dolorem est eligendi esse quae aspernatur sint omnis quia.", 3 },
                    { 4, "Accusantium voluptas veniam rerum minus.", 4 },
                    { 5, "Minus amet officiis quis fuga mollitia.", 5 },
                    { 6, "Provident atque quaerat ut possimus et suscipit quaerat voluptates quam dolore.", 6 },
                    { 7, "Delectus nihil occaecati sunt molestias ea eius nostrum similique.", 7 },
                    { 8, "Debitis provident dolorem ut odit architecto facere facere aliquam.", 8 },
                    { 9, "Architecto est quo rerum molestias recusandae temporibus sint inventore quisquam aut.", 9 },
                    { 10, "Quis ea ut dolorem nostrum aut porro iste dolor et.", 10 },
                    { 11, "Alias blanditiis aspernatur explicabo soluta.", 11 },
                    { 12, "Et minus laborum dolores et in rerum.", 12 },
                    { 13, "Fugiat accusantium quae ullam libero.", 13 },
                    { 14, "Iste omnis aut esse quasi deserunt voluptas.", 14 },
                    { 15, "Harum dicta nam recusandae ratione autem quo molestiae est.", 15 },
                    { 16, "Minus soluta magnam non et qui.", 16 },
                    { 17, "Tempora debitis praesentium eveniet ut inventore rerum quisquam beatae deserunt placeat.", 17 },
                    { 18, "Tempore sequi quidem cumque rem ullam aut.", 18 },
                    { 19, "Aut exercitationem cupiditate id eveniet.", 19 },
                    { 20, "Iure modi ut voluptatem necessitatibus et reprehenderit.", 20 },
                    { 21, "Dicta voluptatem autem vitae ea molestiae delectus cum.", 21 },
                    { 22, "Dolorem architecto eos autem enim rem quia earum atque illum tempora.", 22 },
                    { 23, "Velit tempore et occaecati dolore.", 23 },
                    { 24, "Ut incidunt sint magnam sit illo.", 24 },
                    { 25, "Culpa omnis molestias aut debitis nihil quia cumque magni id.", 25 }
                });

            migrationBuilder.InsertData(
                table: "Flags",
                columns: new[] { "Id", "ArticleId", "CommentId", "DateCreated", "ReportedUserId", "Status", "Type" },
                values: new object[,]
                {
                    { 104, null, null, new DateTime(1997, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 0, 1 },
                    { 105, null, null, new DateTime(1980, 10, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1, 0, 1 },
                    { 106, null, null, new DateTime(1935, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), 2, 0, 1 },
                    { 107, null, null, new DateTime(1973, 10, 11, 0, 0, 0, 0, DateTimeKind.Utc), 2, 0, 1 },
                    { 108, null, null, new DateTime(2018, 12, 21, 0, 0, 0, 0, DateTimeKind.Utc), 2, 0, 1 },
                    { 109, null, null, new DateTime(2014, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), 2, 0, 1 },
                    { 110, null, null, new DateTime(2017, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), 5, 0, 1 },
                    { 111, null, null, new DateTime(1971, 7, 14, 0, 0, 0, 0, DateTimeKind.Utc), 6, 0, 1 },
                    { 112, null, null, new DateTime(2012, 8, 6, 0, 0, 0, 0, DateTimeKind.Utc), 7, 0, 1 },
                    { 113, null, null, new DateTime(1910, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, 0, 1 },
                    { 114, null, null, new DateTime(1956, 3, 8, 0, 0, 0, 0, DateTimeKind.Utc), 8, 0, 1 },
                    { 115, null, null, new DateTime(1990, 11, 12, 0, 0, 0, 0, DateTimeKind.Utc), 8, 0, 1 },
                    { 116, null, null, new DateTime(1982, 9, 3, 0, 0, 0, 0, DateTimeKind.Utc), 8, 0, 1 },
                    { 117, null, null, new DateTime(1951, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), 8, 0, 1 },
                    { 118, null, null, new DateTime(1967, 10, 23, 0, 0, 0, 0, DateTimeKind.Utc), 8, 0, 1 },
                    { 119, null, null, new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Utc), 9, 0, 1 },
                    { 120, null, null, new DateTime(1915, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc), 9, 0, 1 },
                    { 121, null, null, new DateTime(1991, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), 9, 0, 1 },
                    { 122, null, null, new DateTime(1971, 6, 22, 0, 0, 0, 0, DateTimeKind.Utc), 10, 0, 1 },
                    { 123, null, null, new DateTime(1911, 8, 16, 0, 0, 0, 0, DateTimeKind.Utc), 10, 0, 1 },
                    { 124, null, null, new DateTime(1962, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc), 11, 0, 1 },
                    { 125, null, null, new DateTime(1964, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), 12, 0, 1 },
                    { 126, null, null, new DateTime(1959, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), 12, 0, 1 },
                    { 127, null, null, new DateTime(1962, 6, 3, 0, 0, 0, 0, DateTimeKind.Utc), 12, 0, 1 },
                    { 128, null, null, new DateTime(1943, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 13, 0, 1 },
                    { 129, null, null, new DateTime(1978, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc), 14, 0, 1 },
                    { 130, null, null, new DateTime(1935, 3, 18, 0, 0, 0, 0, DateTimeKind.Utc), 14, 0, 1 },
                    { 131, null, null, new DateTime(1944, 6, 8, 0, 0, 0, 0, DateTimeKind.Utc), 14, 0, 1 },
                    { 132, null, null, new DateTime(1962, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc), 15, 0, 1 },
                    { 133, null, null, new DateTime(1962, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc), 16, 0, 1 },
                    { 134, null, null, new DateTime(1973, 2, 21, 0, 0, 0, 0, DateTimeKind.Utc), 16, 0, 1 },
                    { 135, null, null, new DateTime(2009, 7, 20, 0, 0, 0, 0, DateTimeKind.Utc), 17, 0, 1 },
                    { 136, null, null, new DateTime(1990, 8, 25, 0, 0, 0, 0, DateTimeKind.Utc), 17, 0, 1 },
                    { 137, null, null, new DateTime(1907, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), 17, 0, 1 },
                    { 138, null, null, new DateTime(1953, 7, 8, 0, 0, 0, 0, DateTimeKind.Utc), 18, 0, 1 },
                    { 139, null, null, new DateTime(1959, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), 19, 0, 1 },
                    { 140, null, null, new DateTime(2006, 4, 22, 0, 0, 0, 0, DateTimeKind.Utc), 20, 0, 1 },
                    { 141, null, null, new DateTime(2015, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc), 20, 0, 1 },
                    { 142, null, null, new DateTime(1940, 6, 9, 0, 0, 0, 0, DateTimeKind.Utc), 20, 0, 1 },
                    { 143, null, null, new DateTime(1918, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), 20, 0, 1 },
                    { 144, null, null, new DateTime(1986, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc), 20, 0, 1 },
                    { 145, null, null, new DateTime(2002, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), 21, 0, 1 },
                    { 146, null, null, new DateTime(1963, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), 22, 0, 1 },
                    { 147, null, null, new DateTime(1962, 7, 26, 0, 0, 0, 0, DateTimeKind.Utc), 23, 0, 1 },
                    { 148, null, null, new DateTime(1976, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), 23, 0, 1 },
                    { 149, null, null, new DateTime(2008, 8, 27, 0, 0, 0, 0, DateTimeKind.Utc), 23, 0, 1 },
                    { 150, null, null, new DateTime(1982, 7, 6, 0, 0, 0, 0, DateTimeKind.Utc), 23, 0, 1 },
                    { 151, null, null, new DateTime(1962, 7, 27, 0, 0, 0, 0, DateTimeKind.Utc), 24, 0, 1 },
                    { 152, null, null, new DateTime(1971, 9, 11, 0, 0, 0, 0, DateTimeKind.Utc), 24, 0, 1 },
                    { 153, null, null, new DateTime(1908, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), 24, 0, 1 },
                    { 1, 2, null, new DateTime(1978, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 2, 2, null, new DateTime(1919, 8, 30, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 3, 4, null, new DateTime(2002, 6, 29, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 4, 4, null, new DateTime(1964, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 5, 4, null, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 6, 4, null, new DateTime(1962, 5, 13, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 7, 5, null, new DateTime(1914, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 8, 5, null, new DateTime(1956, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 9, 5, null, new DateTime(1963, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 10, 6, null, new DateTime(1965, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 11, 7, null, new DateTime(1914, 7, 21, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 12, 7, null, new DateTime(1962, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 13, 8, null, new DateTime(1959, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 14, 8, null, new DateTime(1922, 6, 20, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 15, 9, null, new DateTime(1997, 3, 9, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 16, 9, null, new DateTime(1969, 8, 29, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 17, 10, null, new DateTime(2018, 5, 31, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 18, 10, null, new DateTime(2010, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 19, 10, null, new DateTime(1977, 9, 7, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 20, 10, null, new DateTime(1965, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 21, 11, null, new DateTime(1917, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 22, 11, null, new DateTime(1927, 12, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 23, 12, null, new DateTime(1926, 2, 28, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 24, 12, null, new DateTime(1958, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 25, 13, null, new DateTime(1927, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 26, 14, null, new DateTime(1969, 10, 31, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 27, 14, null, new DateTime(1912, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 28, 15, null, new DateTime(1950, 11, 18, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 29, 17, null, new DateTime(1956, 12, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 30, 17, null, new DateTime(2011, 7, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 31, 18, null, new DateTime(1973, 12, 19, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 32, 19, null, new DateTime(1932, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 33, 19, null, new DateTime(1979, 7, 6, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 34, 19, null, new DateTime(1905, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 35, 19, null, new DateTime(1987, 3, 9, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 36, 20, null, new DateTime(1936, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 37, 20, null, new DateTime(2017, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 38, 21, null, new DateTime(1965, 2, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 39, 21, null, new DateTime(1965, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 40, 21, null, new DateTime(1919, 6, 19, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 41, 22, null, new DateTime(1953, 4, 13, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 42, 22, null, new DateTime(1984, 8, 29, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 43, 22, null, new DateTime(1957, 5, 17, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 44, 23, null, new DateTime(1947, 4, 24, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 45, 23, null, new DateTime(1932, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 46, 23, null, new DateTime(1922, 7, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 47, 25, null, new DateTime(1982, 3, 13, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 48, 25, null, new DateTime(1962, 9, 16, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 49, 25, null, new DateTime(1951, 8, 27, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 50, 25, null, new DateTime(1964, 3, 13, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 0 },
                    { 51, null, 1, new DateTime(1962, 5, 13, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 52, null, 1, new DateTime(1901, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 53, null, 1, new DateTime(1961, 12, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 54, null, 1, new DateTime(1962, 9, 19, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 55, null, 2, new DateTime(2000, 6, 27, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 56, null, 2, new DateTime(1965, 9, 19, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 57, null, 3, new DateTime(1911, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 58, null, 3, new DateTime(1973, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 59, null, 4, new DateTime(2000, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 60, null, 4, new DateTime(1959, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 61, null, 4, new DateTime(1924, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 62, null, 5, new DateTime(1969, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 63, null, 5, new DateTime(1919, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 64, null, 5, new DateTime(1967, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 65, null, 6, new DateTime(1957, 10, 2, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 66, null, 6, new DateTime(1932, 7, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 67, null, 7, new DateTime(1944, 12, 18, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 68, null, 8, new DateTime(1987, 9, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 69, null, 9, new DateTime(1981, 9, 26, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 70, null, 9, new DateTime(1970, 6, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 71, null, 9, new DateTime(1931, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 72, null, 9, new DateTime(1910, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 73, null, 9, new DateTime(1965, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 74, null, 10, new DateTime(1973, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 75, null, 10, new DateTime(1996, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 76, null, 10, new DateTime(1994, 7, 24, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 77, null, 11, new DateTime(1967, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 78, null, 11, new DateTime(1974, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 79, null, 12, new DateTime(2012, 10, 2, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 80, null, 13, new DateTime(1993, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 81, null, 13, new DateTime(1975, 11, 6, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 82, null, 13, new DateTime(1962, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 83, null, 14, new DateTime(1962, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 84, null, 15, new DateTime(1962, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 85, null, 15, new DateTime(1972, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 86, null, 15, new DateTime(1935, 5, 17, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 87, null, 16, new DateTime(1975, 7, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 88, null, 18, new DateTime(1930, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 89, null, 18, new DateTime(1939, 2, 21, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 90, null, 18, new DateTime(1962, 6, 6, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 91, null, 19, new DateTime(1940, 5, 9, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 92, null, 19, new DateTime(1902, 7, 9, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 93, null, 20, new DateTime(1978, 9, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 94, null, 21, new DateTime(2011, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 95, null, 22, new DateTime(1912, 5, 14, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 96, null, 23, new DateTime(1910, 3, 25, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 97, null, 23, new DateTime(1916, 2, 28, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 98, null, 24, new DateTime(1987, 9, 29, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 99, null, 24, new DateTime(1962, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 100, null, 24, new DateTime(1952, 12, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 101, null, 25, new DateTime(1962, 4, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 102, null, 25, new DateTime(2015, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 },
                    { 103, null, 25, new DateTime(1978, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, 2 }
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
                name: "IX_Flags_ArticleId",
                table: "Flags",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Flags_CommentId",
                table: "Flags",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Flags_ReportedUserId",
                table: "Flags",
                column: "ReportedUserId");
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
