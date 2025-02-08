using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countires",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countires", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReveiveNewsLetters = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.InsertData(
                table: "Countires",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[,]
                {
                    { new Guid("00f7fbcf-5aef-43c3-940d-0e59db32da73"), "Belarus" },
                    { new Guid("03a588c0-576a-4594-b6e0-b9ded72e0141"), "Egypt" },
                    { new Guid("04e647b5-c217-4d11-8f11-56bebf015108"), "China" },
                    { new Guid("0aefe328-788c-4134-bb08-84d79c29225f"), "Poland" },
                    { new Guid("10e6d5bd-ccdb-4e73-983b-04bedf1d0149"), "Bolivia" },
                    { new Guid("13000ac8-9777-42e3-9099-98d0e76e3db6"), "Brazil" },
                    { new Guid("14cab1fa-f33e-49d9-b6fa-26b748d8d4fd"), "China" },
                    { new Guid("225d7ad9-d58d-4217-9b38-fcd730e6e8e6"), "Malta" },
                    { new Guid("22bed691-e4e1-4338-8268-41959e4ab485"), "Spain" },
                    { new Guid("23ff8201-86da-4eb1-a395-ac352221caef"), "Indonesia" },
                    { new Guid("2581049c-c576-41b8-b53e-9e9dbf8607f0"), "Oman" },
                    { new Guid("25e8f514-cfc5-4593-8c27-b4b446264f69"), "Russia" },
                    { new Guid("29fab6eb-811d-4f6e-a53a-ac581c2aa121"), "Belarus" },
                    { new Guid("2d1721fe-cf26-4c55-8201-46fd4e7862bf"), "Kenya" },
                    { new Guid("2db9d38e-eea5-4794-98ab-1bf555a68a27"), "China" },
                    { new Guid("2ddeb142-eafb-43db-a2dc-81bd4ef7d31d"), "Thailand" },
                    { new Guid("2faeba0e-27cf-4fe7-9268-c9908bc1f7c5"), "Russia" },
                    { new Guid("3337ec9f-3fd0-47f9-967e-5b0e8848fa01"), "Kazakhstan" },
                    { new Guid("33e16005-9b2c-486e-9866-d3b1ba00b70b"), "Brazil" },
                    { new Guid("35c445d7-14c7-46be-aed8-3e3c9f4652a0"), "Ukraine" },
                    { new Guid("389adeeb-8047-44a9-9986-9eea99f52b72"), "Ukraine" },
                    { new Guid("3a464655-5f61-4a90-ae00-ce8cbc9eae3e"), "Philippines" },
                    { new Guid("3e12cc7c-0b30-41c9-aa10-9e312db73c4b"), "Burundi" },
                    { new Guid("3f15a430-434f-409a-8840-5d77d299c537"), "Russia" },
                    { new Guid("429f5d40-c382-41f7-8797-2af0bc613da5"), "Czech Republic" },
                    { new Guid("44fcc4f4-3c7f-4627-8dfd-eadfc496f0f7"), "Greece" },
                    { new Guid("4af9be87-1b05-4052-8848-47d607a1193d"), "Indonesia" },
                    { new Guid("4b0f8120-d6aa-4814-af9a-bd860c281713"), "Pakistan" },
                    { new Guid("52821548-bff9-44f3-b7f9-8c6c347cd77c"), "China" },
                    { new Guid("5a467fdf-48b5-456e-a95c-21971404b4ed"), "Macedonia" },
                    { new Guid("5a79ba78-a3e7-4d20-8173-e2d9c7f9c8ca"), "Slovenia" },
                    { new Guid("5c1bcaad-ab73-494c-bce2-5193e852a0db"), "Sweden" },
                    { new Guid("62db2458-2b80-4639-9209-1416a6999fc1"), "Brazil" },
                    { new Guid("6461139a-ff2d-4183-9283-693c6c57ee64"), "Croatia" },
                    { new Guid("690fd409-573b-41b4-93df-9b5e7539ab3a"), "Brazil" },
                    { new Guid("6bac447a-c842-48d0-89e4-7749c9ded2d9"), "Peru" },
                    { new Guid("6d23039e-f055-49c4-8d90-cbdb4caeba7c"), "Mongolia" },
                    { new Guid("6e537a87-cbb1-49d9-8365-9a3dbb03becf"), "United States" },
                    { new Guid("6ea23564-25da-4be5-bea9-2800d7e99e79"), "Norway" },
                    { new Guid("70869731-1e7b-42e8-8f07-b343f77268d7"), "Russia" },
                    { new Guid("73dcf0b6-db54-405c-a423-8abd0fc09f59"), "Indonesia" },
                    { new Guid("73ee6da4-2d46-41cc-85ef-06b2bc143075"), "Indonesia" },
                    { new Guid("75765fb4-0c39-4276-9926-b4edcb363ff6"), "Honduras" },
                    { new Guid("75ca20d3-d67c-4a32-9be6-35e3ca7fb995"), "Indonesia" },
                    { new Guid("767d9683-3928-4c4c-91da-3aa758d1d555"), "Portugal" },
                    { new Guid("76c4fd5c-6667-41e8-b8f9-dd1f8385a727"), "Afghanistan" },
                    { new Guid("79030501-1c99-4e9c-8f89-311d63a3788e"), "China" },
                    { new Guid("7a3dea39-7065-49ff-8c06-9bfec9a161e6"), "United States" },
                    { new Guid("7da78d56-fa7b-4e08-a82f-001430a0c193"), "China" },
                    { new Guid("7db195d3-e319-43fe-b834-ac984e251fe9"), "China" },
                    { new Guid("83cc1837-2403-40dd-b1de-d6ffb84002bd"), "Peru" },
                    { new Guid("856a06a7-90fb-4204-8e5e-64df964dd8db"), "Cuba" },
                    { new Guid("8ca0a31c-e18e-49f5-8a00-ff51a3c90558"), "China" },
                    { new Guid("8d2f1a80-70e9-4692-bc46-48bb6dbddc76"), "China" },
                    { new Guid("8dc1d6a0-6f6c-4d92-aa0f-ad6a0d7b70cc"), "Argentina" },
                    { new Guid("9106ec5d-2dce-40e9-ab8b-35faa8abb219"), "Poland" },
                    { new Guid("9261dbe6-3316-4101-87e3-5a66003ccbb2"), "Indonesia" },
                    { new Guid("96b233c8-6b36-4608-ac2c-ad740f091c60"), "Bolivia" },
                    { new Guid("98406ced-4701-433e-9396-acb458e065ab"), "Russia" },
                    { new Guid("9ac4695c-634d-4113-b184-c0ee1cfb9d15"), "China" },
                    { new Guid("9afadfc0-2514-4662-a8e1-56f0a9a49415"), "Brazil" },
                    { new Guid("9f080ac5-1013-45d9-9f70-98c390dbb6a3"), "Russia" },
                    { new Guid("a25e48f2-feb3-445e-830a-46f93236c129"), "France" },
                    { new Guid("a9aa0a60-4bad-48bb-9013-1855e9df5a56"), "Venezuela" },
                    { new Guid("ad4dfa1a-fc1e-49ab-bce1-a7ce8b7a287b"), "Dominican Republic" },
                    { new Guid("ada004fd-ed40-431e-95b6-a983ff8da460"), "Indonesia" },
                    { new Guid("af8a128c-4529-4a02-82fc-34c7be145e79"), "Poland" },
                    { new Guid("b0fefeef-074c-4b85-a6c0-0abf07e51b14"), "Peru" },
                    { new Guid("b3480be7-1237-49fd-a510-ccf206b9773b"), "Greece" },
                    { new Guid("bc43c87d-0fdb-43f1-8c25-2d8416149693"), "Tajikistan" },
                    { new Guid("bfa521f5-4f02-4819-9f8f-58ae900d0e4c"), "China" },
                    { new Guid("c0eab651-f1fc-48af-b31c-90d319c89b11"), "China" },
                    { new Guid("c5d0b4d4-919b-4487-ab8e-8c373d79d529"), "Cyprus" },
                    { new Guid("c94796c3-9968-450f-9889-ae30fc9e34bf"), "Russia" },
                    { new Guid("cbf6d927-774d-4c48-9f32-cc08f101dc4f"), "Philippines" },
                    { new Guid("cc396b56-b317-4ecf-a0c6-8db3e048d15a"), "France" },
                    { new Guid("cd03dde5-90f2-43b8-8198-65fb8c0b1adc"), "United States" },
                    { new Guid("cfa5792d-f562-47cf-8673-804398c11768"), "Philippines" },
                    { new Guid("cfde6c8d-bc06-413e-abe8-3cbef2980291"), "Norway" },
                    { new Guid("d03ad804-050b-4403-b7f3-9c3a56437fa1"), "Serbia" },
                    { new Guid("d0ba7268-eee5-4126-afdb-9a153ab90f66"), "Brazil" },
                    { new Guid("d47b44bc-b7cf-4aa8-a1b6-7d2134e6231e"), "Russia" },
                    { new Guid("d4feefe3-2105-4275-b8da-1fe40b330785"), "Russia" },
                    { new Guid("d59d04f4-dbaa-4aa9-afda-a240bcfe541e"), "Greece" },
                    { new Guid("d9f3f3b8-1ed5-4e5e-bc7f-10f553e0b03e"), "Philippines" },
                    { new Guid("db67c141-273d-45a1-9eee-807227e3f53f"), "Ivory Coast" },
                    { new Guid("de34e75f-d5c2-494e-acb8-8b68239d458b"), "Poland" },
                    { new Guid("de6064c8-e24f-4b0a-a021-6ebadc70cd33"), "Thailand" },
                    { new Guid("df7a91b9-1fa2-4194-bcd2-55ff754f097a"), "Vietnam" },
                    { new Guid("e46c7d8e-0adc-4247-a262-e6511ad70a81"), "Indonesia" },
                    { new Guid("e52eeb4b-4140-4018-a8d0-850f36a5f6b0"), "Peru" },
                    { new Guid("e56d9481-229c-4aee-98bb-ad6cec5d7ee6"), "Armenia" },
                    { new Guid("e8e1b386-2275-443e-b4d5-fa778449663f"), "China" },
                    { new Guid("e90121f1-9830-4f88-9571-215315167555"), "China" },
                    { new Guid("ed1628c3-7dd6-4cf9-a753-f150d793834a"), "United States" },
                    { new Guid("edb63ce8-88c9-4596-bee6-2b0c6343f7ac"), "China" },
                    { new Guid("f19c2fb2-6d85-4a4a-8d28-cee9a9e76074"), "Russia" },
                    { new Guid("f82c78c8-4483-4633-861b-81515a771ac0"), "China" },
                    { new Guid("f93bd179-f3f7-463f-859b-2eb4ffb99c9d"), "Indonesia" },
                    { new Guid("ff2869df-30df-4ffb-965f-3354cab30c84"), "Canada" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Address", "CountryId", "DateOfBirth", "Email", "Gender", "PersonName", "ReveiveNewsLetters" },
                values: new object[,]
                {
                    { new Guid("00e5df44-ee11-4510-91ef-7d01e89dc05f"), "9573 Sachtjen Parkway", new Guid("c8a08aeb-b599-4ffb-aa7c-175895d9fbbd"), new DateTime(1986, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "jbrimmell15@imgur.com", "Male", "Jessie", null },
                    { new Guid("010a8360-6f24-4537-91cb-b128779687c5"), "6 Crownhardt Park", new Guid("7c401725-cea8-40c4-b153-384eb8264ad2"), new DateTime(1963, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "lblodgett13@earthlink.net", "Male", "Loydie", null },
                    { new Guid("02b53b45-37a5-4a95-b9c6-1607ff254583"), "124 Annamark Plaza", new Guid("645691d9-f78a-4e24-b282-ca737d3bb05b"), new DateTime(1974, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "gzealey1k@amazon.co.uk", "Male", "Grenville", null },
                    { new Guid("068f4951-bbd6-45bd-88d5-560951f6d7a0"), "00834 Sunfield Avenue", new Guid("44fcc4f4-3c7f-4627-8dfd-eadfc496f0f7"), new DateTime(2007, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "mrycroft2k@miibeian.gov.cn", "Male", "Mano", null },
                    { new Guid("0750c018-1dc4-45f9-b4a5-caf42fa95fd0"), "2 Hudson Drive", new Guid("de69755c-44ec-44b4-936d-5239dec03ee9"), new DateTime(1962, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "nrobeson1y@indiatimes.com", "Male", "Nicolas", null },
                    { new Guid("0a3ee835-aaa6-49f8-9ab4-d9f082f4fc50"), "7129 Homewood Point", new Guid("5e31f80a-83fa-42e9-af7d-7e9876924d7b"), new DateTime(2002, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "gsmooteb@liveinternet.ru", "Male", "Giusto", null },
                    { new Guid("0e5e4c7f-4c73-4874-b183-82b1d8815abd"), "19632 Crest Line Center", new Guid("ddcee61c-547d-41e5-b965-647ca9ef632e"), new DateTime(1967, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "dhartwellw@spotify.com", "Female", "Dorette", null },
                    { new Guid("1454eb08-9a09-4c2a-8a2c-4ff52f056f69"), "41927 Fairfield Point", new Guid("0aa6a5d6-434e-41d4-b3f9-f898e25224c0"), new DateTime(2019, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "btimmonsx@squarespace.com", "Male", "Byron", null },
                    { new Guid("1b75e522-95db-4250-935b-4d511bc60945"), "4 Longview Plaza", new Guid("78cc1c2e-f9ca-415d-89dc-50f023e99a5f"), new DateTime(1969, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "vflanagan2a@1688.com", "Female", "Vinnie", null },
                    { new Guid("1cc32cbd-e676-4339-9660-4bbe907fce70"), "7473 Ramsey Park", new Guid("73dcf0b6-db54-405c-a423-8abd0fc09f59"), new DateTime(2014, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "frontree9@odnoklassniki.ru", "Male", "Fredrick", null },
                    { new Guid("1fa2586a-ae0a-42e3-856b-0a151485ffa5"), "935 Warner Hill", new Guid("db67cbc5-3186-49b0-b627-08d3bc5c3df1"), new DateTime(1965, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "bdrinkhall10@domainmarket.com", "Male", "Barton", null },
                    { new Guid("234c8f4a-ac89-49da-9cfe-bcfe585fe0c5"), "66 Briar Crest Pass", new Guid("b3480be7-1237-49fd-a510-ccf206b9773b"), new DateTime(2016, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "nogradyh@vk.com", "Male", "Nico", null },
                    { new Guid("29740e99-8373-4741-9c39-67595fb5436c"), "459 Chinook Alley", new Guid("da79edaa-9618-4c42-82a2-7cc58125508f"), new DateTime(2003, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "mgiordano14@techcrunch.com", "Male", "Mikol", null },
                    { new Guid("2adfe65f-2946-4fc0-a706-344cb82d43c9"), "1188 Barby Alley", new Guid("53d7ef04-a3a1-4bff-8951-1d3aebb7a617"), new DateTime(2012, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "dattwater26@walmart.com", "Female", "Davida", null },
                    { new Guid("33080f09-300e-40cb-a91b-cd6c01a9372c"), "23 Orin Alley", new Guid("00b9e222-6b7b-4034-8b69-81f957e9290d"), new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "oberryguny@npr.org", "Male", "Oates", null },
                    { new Guid("33dbe8ed-cc3d-47f1-87e2-6c8c0fc609eb"), "01066 2nd Road", new Guid("5c694a80-ce41-4ba7-80be-0f91c6646962"), new DateTime(1989, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "clansdown1r@google.de", "Male", "Cirilo", null },
                    { new Guid("3bdca6d5-f622-494f-b85e-25ffceb8c6a5"), "974 Coolidge Hill", new Guid("112a6ee0-416e-4ecc-9420-aad8e2be4d62"), new DateTime(2021, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "sdorran1s@hostgator.com", "Male", "Shelton", null },
                    { new Guid("3fe0fba2-b970-481b-9d44-044013f5ca27"), "57968 Rieder Point", new Guid("ebf0f467-28fd-4efa-a821-061b8ae065d9"), new DateTime(1977, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "aohenehan1m@msu.edu", "Male", "Addison", null },
                    { new Guid("4015e1cb-c241-498d-b19b-625eb00d2131"), "03013 Menomonie Parkway", new Guid("1da442e2-18e6-4e53-9eed-8047433b1aca"), new DateTime(1994, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "cgeorgeau2j@hc360.com", "Female", "Charlena", null },
                    { new Guid("40161560-dd95-43b8-9542-5daf4238009b"), "6227 Graceland Hill", new Guid("bead83c9-57f5-4db6-a353-0f08a4ee1608"), new DateTime(1971, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "djovicic1w@elegantthemes.com", "Female", "Delcine", null },
                    { new Guid("433515b0-d40f-4019-8011-5ba0b24b32a5"), "9130 Corry Junction", new Guid("1f52c879-a9af-4486-a7ad-037472cdfcf1"), new DateTime(2006, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ncaban1h@goodreads.com", "Male", "Nicolai", null },
                    { new Guid("482f681f-3d39-4b17-88c6-3374311555c5"), "0 Macpherson Lane", new Guid("0cb8a47c-f362-4eba-8a94-d4c53b7dabaf"), new DateTime(2005, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "lpudsall1d@arizona.edu", "Male", "Lev", null },
                    { new Guid("4b313f52-f2f9-47b1-abc8-b746e41ff844"), "179 Barby Crossing", new Guid("360d464b-01a5-4e48-b57d-bf696ac029e6"), new DateTime(1995, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "cyakobowitch1f@newyorker.com", "Male", "Chevalier", null },
                    { new Guid("4e279c85-d5b0-4310-8c8e-e55e42acfb29"), "9 Saint Paul Park", new Guid("5245a07f-7e80-48fc-a6aa-75dc22ad035b"), new DateTime(2019, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "mlaugharne6@accuweather.com", "Female", "Mimi", null },
                    { new Guid("4ed11aaf-79ca-49cf-b8f2-c078e59e5898"), "81252 Monica Point", new Guid("3a2d500a-fd68-47be-8e12-70965912acd2"), new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "hmckinn1l@qq.com", "Male", "Had", null },
                    { new Guid("4efb335b-e878-4b90-99e3-ae999b54b851"), "4915 Burning Wood Hill", new Guid("e809326a-f217-44b1-a223-f1d56b5d1655"), new DateTime(2011, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "rbartolomucciq@google.co.uk", "Female", "Rafaelia", null },
                    { new Guid("4f64d56b-dec5-4395-ab6d-b09eac5f3780"), "17122 Sunfield Lane", new Guid("c2e669b2-94c5-4bd6-8605-de11471bac62"), new DateTime(1993, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "biacovo23@yahoo.com", "Female", "Barbe", null },
                    { new Guid("4ffe5c78-22bb-4346-84b4-50127a751578"), "3178 Ruskin Point", new Guid("b3480be7-1237-49fd-a510-ccf206b9773b"), new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "papplebee2f@merriam-webster.com", "Male", "Peder", null },
                    { new Guid("535965ad-4826-41a6-bdd6-fb626361f545"), "23 Riverside Pass", new Guid("facac0a9-e722-4e0f-a7fa-66564e7764fe"), new DateTime(1971, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "mbrumhead1n@privacy.gov.au", "Male", "Mick", null },
                    { new Guid("58a8b1d5-6da3-4c3d-a01f-ae48320c6c98"), "1 Maryland Terrace", new Guid("239e99fa-8841-4ce5-bbda-def112044864"), new DateTime(2012, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "cmeringtonm@amazon.com", "Male", "Clive", null },
                    { new Guid("593df4f8-d51f-4488-835a-1bd65d899679"), "4 Hanover Pass", new Guid("3a03d53f-c597-48fc-ab60-e207074d6761"), new DateTime(2014, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "bcreeghan1j@cbsnews.com", "Female", "Britt", null },
                    { new Guid("5c28edc9-e307-4ac9-820a-772611e6347a"), "004 Corscot Street", new Guid("a509bfd5-c722-47ea-a5e5-b0a50e8ad7ad"), new DateTime(1982, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "eshelsher1u@bloglovin.com", "Female", "Emmaline", null },
                    { new Guid("5cc4f7f4-df9d-4e5d-9cc3-dfb32beb3403"), "575 Mockingbird Hill", new Guid("73dcf0b6-db54-405c-a423-8abd0fc09f59"), new DateTime(1988, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "sjaggif@go.com", "Male", "Sauveur", null },
                    { new Guid("5d6a65a1-4fc2-49be-81a9-1084325b5278"), "79 Larry Drive", new Guid("e44f0e91-3057-476b-b29a-99b56407373d"), new DateTime(1969, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "cdwellingz@narod.ru", "Female", "Christal", null },
                    { new Guid("5f2725de-c114-4619-b15d-405724f85f91"), "5 American Crossing", new Guid("d5ab36b2-8fc1-4980-b6de-9174efa35478"), new DateTime(1965, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "eshotboult18@umich.edu", "Female", "Ethelda", null },
                    { new Guid("6293c692-b3d2-4fba-a203-670bccd8dada"), "9031 Pearson Court", new Guid("523ac391-582e-445e-b73f-d031731ea96e"), new DateTime(1997, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "owickmann2c@scribd.com", "Female", "Odele", null },
                    { new Guid("62d50342-ca53-4838-9f48-bd54fbea32bf"), "45332 Kenwood Lane", new Guid("f04f53e3-be71-4265-9a3a-7da112b4c6a1"), new DateTime(1961, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "lgiven3@hubpages.com", "Female", "Lindsey", null },
                    { new Guid("630cf9e1-85c5-4f69-8cb6-4c3fa5467bdb"), "645 Eagle Crest Junction", new Guid("50b15e67-3a93-4dc3-b55d-201984ee6ca0"), new DateTime(1974, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mredmire1e@opera.com", "Male", "Merwyn", null },
                    { new Guid("64d22bcb-c0d4-41c9-bea1-45884d695657"), "8 Anhalt Drive", new Guid("9da2d5c5-e7a0-466b-a06b-0055899e31fd"), new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "gkay1a@bloomberg.com", "Male", "Gardener", null },
                    { new Guid("65e177bd-166e-45cf-a31c-bc2cef4dee5f"), "19 High Crossing Place", new Guid("3cc073af-931b-4698-aa4c-6002985fab66"), new DateTime(2018, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "rtimmens25@adobe.com", "Male", "Regan", null },
                    { new Guid("664d283f-b74c-420d-9044-560092ba8b60"), "222 Burrows Junction", new Guid("583f288a-a923-4a8b-bd27-37d2bbbf0b28"), new DateTime(1974, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "rhalden8@webeden.co.uk", "Male", "Rockwell", null },
                    { new Guid("6c62058d-3812-4c70-b8ad-78c9bfa72913"), "98013 Dayton Point", new Guid("687c0a36-9d6c-41dd-8bfa-4da094fa3627"), new DateTime(1960, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "tarmalu@themeforest.net", "Male", "Terrel", null },
                    { new Guid("74b60d27-ef63-40e9-8036-49bab029b03c"), "96 Gulseth Park", new Guid("ba4e4670-2267-4b36-8cad-69f110a56a9d"), new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "dlowsely24@oakley.com", "Male", "Darrick", null },
                    { new Guid("74bffc53-3279-40cb-b5c2-55623df2b5ba"), "6 Pond Way", new Guid("3109ae3f-0726-4aec-acdb-77c4a9670466"), new DateTime(1967, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "scarwithimr@wikipedia.org", "Female", "Sondra", null },
                    { new Guid("777aebba-82cb-4f5e-9e5b-8fc231be8594"), "65595 Dunning Plaza", new Guid("e0aa6639-ed09-4d88-a9d9-d9a0467eaecd"), new DateTime(1967, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "acinderey21@storify.com", "Female", "Anne", null },
                    { new Guid("79579206-affb-41a7-8f8d-3345fe8722b7"), "308 Duke Road", new Guid("d9f3f3b8-1ed5-4e5e-bc7f-10f553e0b03e"), new DateTime(2016, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "sbonallicki@pen.io", "Male", "Sylvester", null },
                    { new Guid("7a11317f-a250-476d-88b5-307c2b64e780"), "78209 Coleman Lane", new Guid("49a295a1-4696-4904-9fd8-8e87df08f7e2"), new DateTime(2010, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "gcruce2e@alibaba.com", "Female", "Garnette", null },
                    { new Guid("836b65b2-a34f-412b-9514-5a31b8cc3b49"), "6346 Fuller Place", new Guid("2ea6c710-c703-4292-977b-ecb728a56eae"), new DateTime(1994, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "rtaggart16@bbb.org", "Male", "Rufe", null },
                    { new Guid("871a9ff8-9247-4c84-bd2e-2eb97838c56a"), "512 Bartelt Street", new Guid("c9bb0f8c-998a-4c7b-b096-f3d7dc057306"), new DateTime(2009, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "nmcmeeking12@addtoany.com", "Female", "Netti", null },
                    { new Guid("892ef729-9c88-4e45-a627-1c02f9b23be6"), "9481 Vahlen Parkway", new Guid("896e23f6-a5c3-4bc4-8ff6-847e6f7cb9c8"), new DateTime(1960, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "kkulicke2i@prlog.org", "Male", "Kimble", null },
                    { new Guid("898e056c-0b33-46c1-be71-c5b9e4162a6d"), "623 Kings Street", new Guid("44fcc4f4-3c7f-4627-8dfd-eadfc496f0f7"), new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "cgirardez2m@topsy.com", "Female", "Charleen", null },
                    { new Guid("8a4fd481-4388-406c-9fd2-366109ba899e"), "46114 Sommers Center", new Guid("2292b125-c842-44d2-8b20-550d9f30208e"), new DateTime(1966, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "krames27@weebly.com", "Female", "Ketti", null },
                    { new Guid("8e01b4d8-8bbd-4a7a-a5f5-ffef677820d5"), "5 Summer Ridge Terrace", new Guid("44fcc4f4-3c7f-4627-8dfd-eadfc496f0f7"), new DateTime(2007, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "icathenod2r@ehow.com", "Male", "Iain", null },
                    { new Guid("8f9548a9-f03c-40ff-89e7-cdfc41e522ec"), "123 Birchwood Junction", new Guid("3c68dde9-e578-47cb-944f-b15ad806ac19"), new DateTime(1994, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "mperello1g@arstechnica.com", "Female", "Marie-ann", null },
                    { new Guid("9090d087-6374-44f9-ad1b-93bade4c8cbd"), "94505 Towne Terrace", new Guid("dad068b9-2ae5-4611-b082-eb2aa31ac4be"), new DateTime(2001, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "bfumagalln@ed.gov", "Male", "Bob", null },
                    { new Guid("93d629c2-d1b6-45a8-bc10-a628a74cf0e3"), "55 Londonderry Junction", new Guid("73dcf0b6-db54-405c-a423-8abd0fc09f59"), new DateTime(2017, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "lrickford4@icq.com", "Male", "Leonid", null },
                    { new Guid("97388e3f-44f9-4953-a6df-ea9a84819bd8"), "25 Westerfield Lane", new Guid("b3480be7-1237-49fd-a510-ccf206b9773b"), new DateTime(1966, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "lnannininij@aboutads.info", "Male", "Luis", null },
                    { new Guid("986e1ce3-1a46-47df-96bb-35df1c2663b0"), "4318 Straubel Plaza", new Guid("45dd90ce-c496-4ed1-b99b-497101378b83"), new DateTime(2000, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gwhortonp@ftc.gov", "Female", "Georgeta", null },
                    { new Guid("9d9d5fcc-1550-4d24-89ac-72aeae570e74"), "33123 Pond Point", new Guid("322724f2-9988-4456-8cdc-06818a2af542"), new DateTime(2004, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "mnealeyg@tumblr.com", "Female", "Mei", null },
                    { new Guid("a3366e15-37a7-430c-9a5f-53c61e339140"), "792 Mcguire Lane", new Guid("965d5c91-89e8-4ac6-948a-03ef628f237f"), new DateTime(1963, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "yarrigucci1b@forbes.com", "Female", "Yolanthe", null },
                    { new Guid("a899282c-07eb-456d-90f4-fd359a2c94c2"), "5 Hoepker Lane", new Guid("fca63074-1748-49a9-9557-90fb956c6a1b"), new DateTime(1995, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "npawlett22@ebay.com", "Male", "Nikolaus", null },
                    { new Guid("aa335eb2-5eba-4a61-8d52-005615e68eb2"), "2985 Petterle Park", new Guid("1b505fa3-b87f-4800-956f-a2ea7dee78ac"), new DateTime(2009, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "bkhalida@ning.com", "Male", "Bendicty", null },
                    { new Guid("ab729d0a-8745-4e48-87f8-ecb69ca0a5c2"), "700 School Plaza", new Guid("73dcf0b6-db54-405c-a423-8abd0fc09f59"), new DateTime(1993, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "aprantlc@umich.edu", "Female", "Alex", null },
                    { new Guid("ae5373de-8b3d-41bb-8ff5-2d0b9e77a957"), "7 Lighthouse Bay Point", new Guid("5e4be1d3-2242-4068-8bfb-69bdf07777e0"), new DateTime(1962, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "kklemke1q@zimbio.com", "Male", "Kelwin", null },
                    { new Guid("ae8f71cf-d3fa-4a76-a874-d7e4a8aae812"), "34340 Mosinee Crossing", new Guid("d99aa73e-5947-4a78-bbd9-7843fedb5023"), new DateTime(2004, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "cmatus17@reddit.com", "Male", "Creigh", null },
                    { new Guid("af05f9d5-5666-40b1-8621-378a1c729605"), "4954 Carioca Drive", new Guid("73dcf0b6-db54-405c-a423-8abd0fc09f59"), new DateTime(1983, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "rmacneish2@prlog.org", "Female", "Rozina", null },
                    { new Guid("b1dd012b-6a28-41a2-8c53-1d4e09159b5e"), "851 Havey Center", new Guid("d7f5eb43-5f67-4267-93e9-ed256290bcf6"), new DateTime(1973, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "rstaress@hostgator.com", "Male", "Reinold", null },
                    { new Guid("b286e3e3-9d71-49aa-a9c1-5d6e27539d52"), "8180 Dixon Road", new Guid("9a97adf3-331e-4e47-bf28-7ea3eca1564d"), new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "ipolglase2p@amazon.com", "Female", "Idette", null },
                    { new Guid("b3c8c68e-5bc8-465a-962b-602aac960bae"), "70 Vidon Road", new Guid("df415113-67b3-445e-8736-1d62e5db0477"), new DateTime(2000, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "dadamsson1c@oaic.gov.au", "Female", "Dode", null },
                    { new Guid("b4306d35-e70b-4d28-933c-e1626bd6de30"), "27 Declaration Pass", new Guid("0ba420d9-3662-4c44-a3dd-eb4f83c9059d"), new DateTime(2007, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "jhendrichs1p@symantec.com", "Male", "Judah", null },
                    { new Guid("b528f68b-517c-4053-9c59-bb1114a866fb"), "077 Redwing Court", new Guid("b3480be7-1237-49fd-a510-ccf206b9773b"), new DateTime(2011, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "acalton2d@oracle.com", "Male", "Alf", null },
                    { new Guid("b5da50e3-f07f-4333-8c60-cc4a7fbca432"), "4 Red Cloud Parkway", new Guid("cec10c1c-6ce1-433c-b46b-193e352c5a39"), new DateTime(1974, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ktreuget@discuz.net", "Female", "Kerrie", null },
                    { new Guid("b765b035-49b4-4446-91ac-3c6290caa698"), "7500 Warbler Parkway", new Guid("88cf16f9-58ee-4e8e-9767-09c5140b1e9d"), new DateTime(1998, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "hmaynard11@answers.com", "Male", "Hube", null },
                    { new Guid("c1e43fac-7932-49e2-91f5-1d1a50b612c3"), "521 Utah Park", new Guid("f9185286-2329-4b59-bd8e-7cd782c2d524"), new DateTime(1961, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "edragoe2b@google.ru", "Male", "Evin", null },
                    { new Guid("c616db68-0d9e-4bd5-990e-e75f0aa7bf80"), "2604 Stone Corner Lane", new Guid("18b0512a-c07e-4571-80b0-9d847f76d972"), new DateTime(1970, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bsirey2g@oakley.com", "Male", "Bradan", null },
                    { new Guid("ca84d6c0-6352-464f-8013-684825ce7ae8"), "71526 Bowman Way", new Guid("fe9ce14a-1ce2-4095-b69f-04b8a84db160"), new DateTime(2011, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mmasden2l@hubpages.com", "Female", "Meridith", null },
                    { new Guid("cb1a930b-fe85-45b6-a9fc-da9fef581bee"), "857 Bashford Point", new Guid("7b281a9f-2d8d-4257-8170-9d658a9a08a9"), new DateTime(1965, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "rferriday2n@instagram.com", "Female", "Rhiamon", null },
                    { new Guid("cd32ba2d-383a-40fa-8650-8aff708d4ad9"), "85 Shoshone Center", new Guid("6ecee186-b599-4bab-bd83-4c4c1bb1e3af"), new DateTime(1965, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "hyegorevd@hhs.gov", "Female", "Heath", null },
                    { new Guid("cd6f239e-beb1-4dcd-b599-812c53dcdc7b"), "870 Sauthoff Plaza", new Guid("60e30830-09a8-402c-8652-c961d991482b"), new DateTime(2020, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "wcommings2h@drupal.org", "Male", "Wayne", null },
                    { new Guid("ce6b0ea8-58bf-45c8-888f-fd7a3278a618"), "43448 Summer Ridge Pass", new Guid("176309fa-75a0-4375-8159-145d12470e4b"), new DateTime(2000, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "nridgewaye@ftc.gov", "Female", "Noelle", null },
                    { new Guid("cfa36633-6744-4ed3-94ec-80a6a24d1382"), "4318 Bluestem Park", new Guid("48a407bc-831f-4256-aaf0-e3af015477d0"), new DateTime(1996, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "cglassfordv@sogou.com", "Female", "Cindie", null },
                    { new Guid("dac7a99e-73e6-411d-bcfa-22c4a438c2ef"), "21 Comanche Trail", new Guid("f3d925e8-a53d-4f60-8d02-c610e5cd5bda"), new DateTime(1987, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "tcorney29@nyu.edu", "Male", "Terrill", null },
                    { new Guid("de5a1be0-0a01-4192-9aa2-b027d093ced0"), "9 Eagan Trail", new Guid("44fd5ad1-ffda-4edc-82bb-8700b2fe7f99"), new DateTime(1976, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "gayling19@hugedomains.com", "Female", "Georgeanne", null },
                    { new Guid("df88c5f6-ab69-4ef1-b1ec-a0df897e5a9d"), "1 Pleasure Hill", new Guid("abc9f94a-bdbf-41d1-848a-412085078349"), new DateTime(1996, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "ibernardl@dion.ne.jp", "Male", "Ingra", null },
                    { new Guid("e0fc98f5-146c-4dfb-8b39-0828695d9eca"), "7 Lien Trail", new Guid("44fcc4f4-3c7f-4627-8dfd-eadfc496f0f7"), new DateTime(1990, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "bsustin2q@hubpages.com", "Male", "Boycie", null },
                    { new Guid("e37a46e5-ca29-41f4-8f7d-4aab60a7d3f4"), "05 Alpine Road", new Guid("45e8c6b2-1963-4d74-813d-f0bedfdd3ea3"), new DateTime(1992, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "blenthall1z@wikimedia.org", "Male", "Briggs", null },
                    { new Guid("e53bbf9c-7e31-43f4-9b40-b7bc8275644d"), "66 Lyons Terrace", new Guid("3359773f-dbd0-47ea-94d2-51a4ad57b32b"), new DateTime(1963, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "sshafier7@google.nl", "Female", "Stephine", null },
                    { new Guid("e71ad1be-3b34-4ed7-8506-5dce2decb9ff"), "43 Beilfuss Court", new Guid("3ab01732-e98b-46a2-8dda-15a30fd161cb"), new DateTime(1985, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "sregardsoe5@blogs.com", "Female", "Sheila-kathryn", null },
                    { new Guid("e863822d-a503-4339-b540-48581ef634d1"), "5 Spenser Terrace", new Guid("19b5d253-9118-4101-bc28-54bdd573edc8"), new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "jjustun1o@wikia.com", "Female", "Jacinthe", null },
                    { new Guid("eb6c254e-218e-4090-a045-9ad9db5772ea"), "84 Talisman Crossing", new Guid("44fcc4f4-3c7f-4627-8dfd-eadfc496f0f7"), new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "jgoakes2o@delicious.com", "Female", "Joletta", null },
                    { new Guid("ebbfe6a4-2d6d-4f4d-81ed-9c4cedbed6e4"), "0759 Utah Place", new Guid("b3480be7-1237-49fd-a510-ccf206b9773b"), new DateTime(1982, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "vpetrano@unicef.org", "Male", "Vlad", null },
                    { new Guid("ec57bd78-97d3-4097-96d9-2f1103bebf0a"), "54016 Warrior Way", new Guid("6b8ca26c-32a9-470d-83a1-0e364325f8f7"), new DateTime(1975, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "jyelden1v@theguardian.com", "Female", "Jodie", null },
                    { new Guid("ed23ae0e-fb8c-4c06-8928-4e60ee2f5e37"), "04434 Jana Terrace", new Guid("73dcf0b6-db54-405c-a423-8abd0fc09f59"), new DateTime(1972, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "ptales1@economist.com", "Male", "Paolo", null },
                    { new Guid("f34cf05a-6a76-4cd3-92b9-e3387bd30caf"), "6 Rockefeller Circle", new Guid("5831fd3b-e966-453d-97c5-2afa3161f4cf"), new DateTime(1998, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "pmalins20@umich.edu", "Female", "Patsy", null },
                    { new Guid("f63bb814-b97d-4d99-a587-398717a3ef95"), "1 Linden Plaza", new Guid("f39fdcd3-fb53-4e9d-8979-c3d1a1282bbe"), new DateTime(2009, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "fkynge1x@squarespace.com", "Male", "Frederigo", null },
                    { new Guid("f8786009-6860-46ea-9f45-3aa48ac5191e"), "28084 Autumn Leaf Drive", new Guid("52622caa-9426-4a7d-b0da-8bcc5b3490c1"), new DateTime(1962, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "klowrance28@mashable.com", "Male", "Kippy", null },
                    { new Guid("fc0f9d87-220c-42a3-b536-b91a5114a256"), "74675 American Ash Street", new Guid("9a2e2e9c-557d-4210-8bfa-74e41a612f4f"), new DateTime(2000, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "mvaud1i@fda.gov", "Female", "Martica", null },
                    { new Guid("fccea9df-d1bd-429f-ab47-fe80467e7cfa"), "5 Carey Parkway", new Guid("0f2fafaa-bc4c-4cc1-aa95-456e8eb0f8bc"), new DateTime(1983, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "bstauntonk@odnoklassniki.ru", "Male", "Bryon", null },
                    { new Guid("fdde3428-f2ac-4066-a514-82cde31955ff"), "4185 Valley Edge Junction", new Guid("5a195ffd-b6b6-4fe2-96e3-f66ef680433d"), new DateTime(1968, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "gwivell1t@narod.ru", "Female", "Gina", null },
                    { new Guid("fe7588da-af2d-40df-b942-f4f90e65bcc6"), "94114 Loomis Road", new Guid("d9f3f3b8-1ed5-4e5e-bc7f-10f553e0b03e"), new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "elindermann0@baidu.com", "Male", "Eberhard", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countires");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
