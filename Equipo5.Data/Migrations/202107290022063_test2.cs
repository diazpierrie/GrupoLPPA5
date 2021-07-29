namespace Equipo5.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Product", name: "CategoriaProductoId", newName: "CategoryId");
            RenameIndex(table: "dbo.Product", name: "IX_CategoriaProductoId", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Product", name: "IX_CategoryId", newName: "IX_CategoriaProductoId");
            RenameColumn(table: "dbo.Product", name: "CategoryId", newName: "CategoriaProductoId");
        }
    }
}
