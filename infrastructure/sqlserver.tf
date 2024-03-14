module "azuresql" {
  source = ".//modules/arm-azure-sql-server"

  depends_on = [
    module.key_vault
  ]
  # Azure SQL Server

  names               = module.config.names
  resource_group_name = module.baseline.resource_groups[var.sqlserver.resource_group_index].name
  location            = module.baseline.resource_groups[var.sqlserver.resource_group_index].location
  sqlversion          = var.sqlserver.sqlversion
  tlsver              = var.sqlserver.tlsversion

  tags = var.tags

  # Default database

  db_name_suffix = var.sqlserver.db_name_suffix
  collation      = var.sqlserver.collation
  licence_type   = var.sqlserver.licence_type
  max_gb         = var.sqlserver.max_gb
  read_scale     = var.sqlserver.read_scale
  sku            = var.sqlserver.sku

}

