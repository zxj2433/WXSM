using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using WalkingTec.Mvvm.Core;
using WXSM.Model;

namespace WXSM.DataAccess
{
    public class DataContext : FrameworkContext
    {
        public DataContext(CS cs)
             : base(cs)
        {
        }

        public DataContext(string cs, DBTypeEnum dbtype, string version=null)
             : base(cs, dbtype, version)
        {
        }
        public DbSet<Area> Areas { get; set; }
        public DbSet<OperateCategorie> operateCategories { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<ShopItemAttribute> shopItemAttributes { get; set; }
        public DbSet<ShopItemImage> ShopItemImages { get; set; }
        public DbSet<ShopItemPrice> ShopItemPrices { get; set; }
        public DbSet<ShopItemStock> ShopItemStocks { get; set; }
        public DbSet<WxErro> WxErros { get; set; }
        public DbSet<SubErro> SubErros { get; set; }
        public DbSet<ItemPriceDiscount> itemPriceDiscounts { get; set; }
        public DbSet<SysPar> syspars { get; set; }
        public DbSet<TradeOrder> TradeOrders{get;set;}
        public DbSet<ShopTradeItem> shopTradeItems{get;set;}
        public DbSet<ShopTradeConsignee> shopTradeConsignees{get;set;}
        public DbSet<ShopTradeInvoice> shopTradeInvoices{get;set;}
        public DbSet<PricingStrategy> pricingStrategies { get; set; }
        public DbSet<PricingStrategyLin> pricingStrategyLins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopItem>().HasIndex(c => c.barcode);
            modelBuilder.Entity<ShopItem>().HasIndex(c => c.title);
            modelBuilder.Entity<ShopItem>().HasIndex(c => c.on_shelf);
            base.OnModelCreating(modelBuilder);
        }
    }

    /// <summary>
    /// DesignTimeFactory for EF Migration, use your full connection string,
    /// EF will find this class and use the connection defined here to run Add-Migration and Update-Database
    /// </summary>
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            return new DataContext("Server=192.168.0.18;Database=WXSM_db;userid=root;pwd=zxj@123#;sslMode=None;Command TimeOut=0;", DBTypeEnum.MySql);
            //return new DataContext("Server=192.168.0.18;Database=WXSM_db;userid=root;pwd=zxj@123#;sslMode=None;", DBTypeEnum.MySql);
        }
    }

}
