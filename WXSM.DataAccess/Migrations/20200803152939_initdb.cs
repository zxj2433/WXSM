using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WXSM.DataAccess.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionLogs",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModuleName = table.Column<string>(maxLength: 50, nullable: true),
                    ActionName = table.Column<string>(maxLength: 50, nullable: true),
                    ITCode = table.Column<string>(maxLength: 50, nullable: true),
                    ActionUrl = table.Column<string>(maxLength: 250, nullable: true),
                    ActionTime = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<double>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    LogType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLogs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 1000, nullable: true),
                    parentID = table.Column<int>(nullable: true),
                    updatetime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Areas_Areas_parentID",
                        column: x => x.parentID,
                        principalTable: "Areas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileAttachments",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    FileName = table.Column<string>(nullable: false),
                    FileExt = table.Column<string>(maxLength: 10, nullable: false),
                    Path = table.Column<string>(nullable: true),
                    Length = table.Column<long>(nullable: false),
                    UploadTime = table.Column<DateTime>(nullable: false),
                    IsTemprory = table.Column<bool>(nullable: false),
                    SaveFileMode = table.Column<int>(nullable: true),
                    GroupName = table.Column<string>(maxLength: 50, nullable: true),
                    FileData = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAttachments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FrameworkDomains",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    DomainName = table.Column<string>(maxLength: 50, nullable: false),
                    DomainAddress = table.Column<string>(maxLength: 50, nullable: false),
                    DomainPort = table.Column<int>(nullable: true),
                    EntryUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkDomains", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FrameworkGroups",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    GroupCode = table.Column<string>(maxLength: 100, nullable: false),
                    GroupName = table.Column<string>(maxLength: 50, nullable: false),
                    GroupRemark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkGroups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FrameworkRoles",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    RoleCode = table.Column<string>(maxLength: 100, nullable: false),
                    RoleName = table.Column<string>(maxLength: 50, nullable: false),
                    RoleRemark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkRoles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "operateCategories",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    oc_code = table.Column<string>(nullable: true),
                    oc_name = table.Column<string>(nullable: true),
                    parent_code = table.Column<string>(nullable: true),
                    parent = table.Column<bool>(nullable: false),
                    OperateCategorieID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operateCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_operateCategories_operateCategories_OperateCategorieID",
                        column: x => x.OperateCategorieID,
                        principalTable: "operateCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false),
                    RefreshToken = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "shopItemAttributes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    editor_recommendation = table.Column<string>(nullable: true),
                    content_introduce = table.Column<string>(nullable: true),
                    catalog = table.Column<string>(nullable: true),
                    digest = table.Column<string>(nullable: true),
                    author_introduce = table.Column<string>(nullable: true),
                    preface = table.Column<string>(nullable: true),
                    media_comment = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    author = table.Column<string>(nullable: true),
                    edition = table.Column<string>(maxLength: 1000, nullable: true),
                    impression = table.Column<string>(maxLength: 1000, nullable: true),
                    publish_house = table.Column<string>(maxLength: 1000, nullable: true),
                    publish_date = table.Column<DateTime>(nullable: true),
                    printing_date = table.Column<DateTime>(nullable: true),
                    size = table.Column<string>(maxLength: 1000, nullable: true),
                    binding = table.Column<string>(maxLength: 1000, nullable: true),
                    words_num = table.Column<string>(maxLength: 1000, nullable: true),
                    page_num = table.Column<string>(maxLength: 1000, nullable: true),
                    clc = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopItemAttributes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShopItemPrices",
                columns: table => new
                {
                    item_id = table.Column<int>(nullable: false),
                    settle_price = table.Column<double>(nullable: false),
                    sell_price = table.Column<double>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItemPrices", x => x.item_id);
                });

            migrationBuilder.CreateTable(
                name: "ShopItemStocks",
                columns: table => new
                {
                    item_id = table.Column<int>(nullable: false),
                    stock = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItemStocks", x => x.item_id);
                });

            migrationBuilder.CreateTable(
                name: "shopTradeConsignees",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    consignee = table.Column<string>(maxLength: 30, nullable: true),
                    phone = table.Column<string>(maxLength: 11, nullable: true),
                    mobile = table.Column<string>(maxLength: 11, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    zipCode = table.Column<string>(maxLength: 10, nullable: true),
                    country = table.Column<int>(nullable: false),
                    province = table.Column<int>(nullable: false),
                    city = table.Column<int>(nullable: false),
                    district = table.Column<int>(nullable: false),
                    town = table.Column<int>(nullable: false),
                    address = table.Column<string>(maxLength: 500, nullable: true),
                    remark = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopTradeConsignees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "shopTradeInvoices",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    titleType = table.Column<string>(maxLength: 50, nullable: true),
                    invoiceType = table.Column<int>(nullable: false),
                    title = table.Column<string>(maxLength: 50, nullable: true),
                    registerno = table.Column<string>(maxLength: 50, nullable: true),
                    bank = table.Column<string>(maxLength: 50, nullable: true),
                    phone = table.Column<string>(maxLength: 20, nullable: true),
                    address = table.Column<string>(maxLength: 500, nullable: true),
                    bankAccount = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopTradeInvoices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "syspars",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    parTitle = table.Column<int>(nullable: false),
                    parValue = table.Column<string>(nullable: true),
                    remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_syspars", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WxErros",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    code = table.Column<string>(nullable: true),
                    errotoken = table.Column<string>(nullable: true),
                    solution = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WxErros", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FrameworkUsers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ITCode = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 32, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Sex = table.Column<int>(nullable: true),
                    CellPhone = table.Column<string>(nullable: true),
                    HomePhone = table.Column<string>(maxLength: 30, nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    PhotoId = table.Column<Guid>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FrameworkUsers_FileAttachments_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "FileAttachments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FrameworkMenus",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    PageName = table.Column<string>(maxLength: 50, nullable: false),
                    ActionName = table.Column<string>(nullable: true),
                    ModuleName = table.Column<string>(nullable: true),
                    FolderOnly = table.Column<bool>(nullable: false),
                    IsInherit = table.Column<bool>(nullable: false),
                    ClassName = table.Column<string>(nullable: true),
                    MethodName = table.Column<string>(nullable: true),
                    DomainId = table.Column<Guid>(nullable: true),
                    ShowOnMenu = table.Column<bool>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    IsInside = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    ICon = table.Column<string>(maxLength: 50, nullable: true),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkMenus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FrameworkMenus_FrameworkDomains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "FrameworkDomains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FrameworkMenus_FrameworkMenus_ParentId",
                        column: x => x.ParentId,
                        principalTable: "FrameworkMenus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShopItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    item_id = table.Column<int>(nullable: false),
                    out_item_id = table.Column<string>(maxLength: 1000, nullable: true),
                    title = table.Column<string>(maxLength: 1000, nullable: true),
                    selling_points = table.Column<string>(maxLength: 1000, nullable: true),
                    freight_free = table.Column<bool>(nullable: true),
                    freight = table.Column<int>(nullable: true),
                    presell = table.Column<bool>(nullable: true),
                    presell_time = table.Column<DateTime>(nullable: true),
                    on_shelf = table.Column<bool>(nullable: true),
                    stock = table.Column<int>(nullable: true),
                    list_price = table.Column<double>(nullable: true),
                    complex_type = table.Column<string>(maxLength: 1000, nullable: true),
                    barcode = table.Column<string>(maxLength: 100, nullable: true),
                    oc_code = table.Column<string>(maxLength: 1000, nullable: true),
                    oc_name = table.Column<string>(maxLength: 1000, nullable: true),
                    sc_code = table.Column<string>(maxLength: 1000, nullable: true),
                    sc_name = table.Column<string>(maxLength: 1000, nullable: true),
                    shop_item_attributeID = table.Column<int>(nullable: true),
                    shop_item_priceitem_id = table.Column<int>(nullable: true),
                    Stockitem_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShopItems_ShopItemStocks_Stockitem_id",
                        column: x => x.Stockitem_id,
                        principalTable: "ShopItemStocks",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopItems_shopItemAttributes_shop_item_attributeID",
                        column: x => x.shop_item_attributeID,
                        principalTable: "shopItemAttributes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopItems_ShopItemPrices_shop_item_priceitem_id",
                        column: x => x.shop_item_priceitem_id,
                        principalTable: "ShopItemPrices",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TradeOrders",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Mall = table.Column<int>(nullable: true),
                    wx_trade_id = table.Column<string>(maxLength: 50, nullable: true),
                    trade_status = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    outerTrade = table.Column<string>(maxLength: 50, nullable: true),
                    sellType = table.Column<string>(maxLength: 50, nullable: true),
                    SType = table.Column<int>(nullable: true),
                    purchaseTime = table.Column<DateTime>(nullable: false),
                    listPrice = table.Column<double>(nullable: false),
                    deliveryType = table.Column<string>(maxLength: 20, nullable: true),
                    DType = table.Column<int>(nullable: true),
                    wayBill = table.Column<string>(maxLength: 500, nullable: true),
                    stockOutOption = table.Column<string>(maxLength: 50, nullable: true),
                    maxDeliveryTime = table.Column<DateTime>(nullable: false),
                    dc = table.Column<string>(maxLength: 50, nullable: true),
                    salePrice = table.Column<double>(nullable: false),
                    deliveryFee = table.Column<double>(nullable: false),
                    tradeConsigneeID = table.Column<Guid>(nullable: true),
                    invoiceType = table.Column<string>(maxLength: 50, nullable: true),
                    PayPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeOrders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TradeOrders_shopTradeConsignees_tradeConsigneeID",
                        column: x => x.tradeConsigneeID,
                        principalTable: "shopTradeConsignees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubErros",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    message = table.Column<string>(nullable: true),
                    WxErroID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubErros", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubErros_WxErros_WxErroID",
                        column: x => x.WxErroID,
                        principalTable: "WxErros",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataPrivileges",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    GroupId = table.Column<Guid>(nullable: true),
                    TableName = table.Column<string>(maxLength: 50, nullable: false),
                    RelateId = table.Column<string>(nullable: true),
                    DomainId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPrivileges", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DataPrivileges_FrameworkDomains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "FrameworkDomains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataPrivileges_FrameworkGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "FrameworkGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataPrivileges_FrameworkUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "FrameworkUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FrameworkUserGroup",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkUserGroup", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FrameworkUserGroup_FrameworkGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "FrameworkGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FrameworkUserGroup_FrameworkUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "FrameworkUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FrameworkUserRole",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkUserRole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FrameworkUserRole_FrameworkRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "FrameworkRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FrameworkUserRole_FrameworkUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "FrameworkUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SearchConditions",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Condition = table.Column<string>(nullable: true),
                    VMName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchConditions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SearchConditions_FrameworkUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "FrameworkUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FunctionPrivileges",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    RoleId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    MenuItemId = table.Column<Guid>(nullable: false),
                    Allowed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionPrivileges", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FunctionPrivileges_FrameworkMenus_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "FrameworkMenus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "itemPriceDiscounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    item_id = table.Column<int>(nullable: false),
                    ShopItemID = table.Column<int>(nullable: false),
                    discount = table.Column<double>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemPriceDiscounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_itemPriceDiscounts_ShopItems_ShopItemID",
                        column: x => x.ShopItemID,
                        principalTable: "ShopItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopItemImages",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    winxuan_image_url = table.Column<string>(nullable: true),
                    image_type = table.Column<string>(nullable: true),
                    index = table.Column<int>(nullable: false),
                    ShopItemID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItemImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShopItemImages_ShopItems_ShopItemID",
                        column: x => x.ShopItemID,
                        principalTable: "ShopItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shopTradeItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    outItemId = table.Column<string>(maxLength: 50, nullable: true),
                    itemID = table.Column<int>(maxLength: 50, nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    sDesc = table.Column<string>(nullable: true),
                    salePrice = table.Column<double>(nullable: false),
                    listPrice = table.Column<double>(nullable: false),
                    purchaseQuantity = table.Column<int>(nullable: false),
                    alcQty = table.Column<int>(nullable: false),
                    OrderID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopTradeItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_shopTradeItems_TradeOrders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "TradeOrders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shopTradeItems_ShopItems_itemID",
                        column: x => x.itemID,
                        principalTable: "ShopItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_parentID",
                table: "Areas",
                column: "parentID");

            migrationBuilder.CreateIndex(
                name: "IX_DataPrivileges_DomainId",
                table: "DataPrivileges",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPrivileges_GroupId",
                table: "DataPrivileges",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPrivileges_UserId",
                table: "DataPrivileges",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkMenus_DomainId",
                table: "FrameworkMenus",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkMenus_ParentId",
                table: "FrameworkMenus",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUserGroup_GroupId",
                table: "FrameworkUserGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUserGroup_UserId",
                table: "FrameworkUserGroup",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUserRole_RoleId",
                table: "FrameworkUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUserRole_UserId",
                table: "FrameworkUserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUsers_ITCode",
                table: "FrameworkUsers",
                column: "ITCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUsers_PhotoId",
                table: "FrameworkUsers",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionPrivileges_MenuItemId",
                table: "FunctionPrivileges",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_itemPriceDiscounts_ShopItemID",
                table: "itemPriceDiscounts",
                column: "ShopItemID");

            migrationBuilder.CreateIndex(
                name: "IX_operateCategories_OperateCategorieID",
                table: "operateCategories",
                column: "OperateCategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_SearchConditions_UserId",
                table: "SearchConditions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemImages_ShopItemID",
                table: "ShopItemImages",
                column: "ShopItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_Stockitem_id",
                table: "ShopItems",
                column: "Stockitem_id");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_barcode",
                table: "ShopItems",
                column: "barcode");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_shop_item_attributeID",
                table: "ShopItems",
                column: "shop_item_attributeID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_shop_item_priceitem_id",
                table: "ShopItems",
                column: "shop_item_priceitem_id");

            migrationBuilder.CreateIndex(
                name: "IX_shopTradeItems_OrderID",
                table: "shopTradeItems",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_shopTradeItems_itemID",
                table: "shopTradeItems",
                column: "itemID");

            migrationBuilder.CreateIndex(
                name: "IX_SubErros_WxErroID",
                table: "SubErros",
                column: "WxErroID");

            migrationBuilder.CreateIndex(
                name: "IX_TradeOrders_tradeConsigneeID",
                table: "TradeOrders",
                column: "tradeConsigneeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionLogs");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "DataPrivileges");

            migrationBuilder.DropTable(
                name: "FrameworkUserGroup");

            migrationBuilder.DropTable(
                name: "FrameworkUserRole");

            migrationBuilder.DropTable(
                name: "FunctionPrivileges");

            migrationBuilder.DropTable(
                name: "itemPriceDiscounts");

            migrationBuilder.DropTable(
                name: "operateCategories");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "SearchConditions");

            migrationBuilder.DropTable(
                name: "ShopItemImages");

            migrationBuilder.DropTable(
                name: "shopTradeInvoices");

            migrationBuilder.DropTable(
                name: "shopTradeItems");

            migrationBuilder.DropTable(
                name: "SubErros");

            migrationBuilder.DropTable(
                name: "syspars");

            migrationBuilder.DropTable(
                name: "FrameworkGroups");

            migrationBuilder.DropTable(
                name: "FrameworkRoles");

            migrationBuilder.DropTable(
                name: "FrameworkMenus");

            migrationBuilder.DropTable(
                name: "FrameworkUsers");

            migrationBuilder.DropTable(
                name: "TradeOrders");

            migrationBuilder.DropTable(
                name: "ShopItems");

            migrationBuilder.DropTable(
                name: "WxErros");

            migrationBuilder.DropTable(
                name: "FrameworkDomains");

            migrationBuilder.DropTable(
                name: "FileAttachments");

            migrationBuilder.DropTable(
                name: "shopTradeConsignees");

            migrationBuilder.DropTable(
                name: "ShopItemStocks");

            migrationBuilder.DropTable(
                name: "shopItemAttributes");

            migrationBuilder.DropTable(
                name: "ShopItemPrices");
        }
    }
}
