param serverfarm_name string = '${uniqueString(resourceGroup().id)}-appsvc'
param appservice_name string = '${uniqueString(resourceGroup().id)}-api'
param location string = resourceGroup().location
param sku string = 'F1'

resource serverFarms 'Microsoft.Web/serverfarms@2021-01-15' = {
  name: serverfarm_name
  location: resourceGroup().location
  sku: {
    name: sku
  }
  kind: 'app'
}

resource graphirApi 'Microsoft.Web/sites@2021-01-15' = {
  kind: 'app'
  name: appservice_name
  location: location
  properties: {
    serverFarmId: serverFarms.id
    siteConfig: {
      netFrameworkVersion: 'v5.0'
    }
  }
}

output appServiceAppName string = graphirApi.name
