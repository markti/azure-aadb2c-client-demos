resource "azurerm_resource_group" "main" {
  name     = "rg-b2c"
  location = "Central US"
}

resource "azurerm_aadb2c_directory" "main" {
    
  country_code            = "US"
  data_residency_location = "United States"
  display_name            = var.b2c_tenant_name
  domain_name             = "${var.b2c_tenant_name}.onmicrosoft.com"
  resource_group_name     = azurerm_resource_group.main.name
  sku_name                = var.b2c_sku

}