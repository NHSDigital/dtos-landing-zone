module "functionapp" {
  source = ".//modules/function-app"

  fnapp_count         = var.function_app.fnapp_count
  name                = module.config.names.function-app
  resource_group_name = module.baseline.resource_groups[var.function_app.resource_group_index].name
  location            = module.baseline.resource_groups[var.function_app.resource_group_index].location

  asp_id     = module.app-plan.app_service_plan_id
  sa_name    = module.storage.storage_account_name
  sa_prm_key = module.storage.storage_account_primary_access_key

  tags = var.tags

}
