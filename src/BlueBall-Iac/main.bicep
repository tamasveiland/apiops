@description('The name of the API Management instance to deploy this API to.')
param serviceName string

@description('The name of the API to create.')
param apiName string

@description('The path to the OpenApi specification file (json).')
param openApiSpecification string

resource apimService 'Microsoft.ApiManagement/service@2022-04-01-preview' existing = {
  name: serviceName
}

@description('The API version')
param apiVersion string = ''

@description('The (optional) service URL')
param serviceUrl string = ''

@description('The API description')
param apiDescription string = ''

module petstoreApi './modules/api-management-openapi.bicep' = {
  name: 'petstoreApi'
  params: {
    serviceName: serviceName
    apiName: apiName
    apiDescription: apiDescription
    serviceUrl: serviceUrl
    openApiSpecification: openApiSpecification
    apiVersion: apiVersion
  }
  dependsOn: [
    apimService
  ]
}
