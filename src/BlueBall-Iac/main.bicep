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

module petstoreApi './modules/api-management-openapi.bicep' = {
  name: 'petstoreApi'
  params: {
    serviceName: serviceName
    apiName: apiName
    apiDescription: 'See petstore3.swagger.io'
    serviceUrl: 'https://petstore3.swagger.io/api/v3'
    openApiSpecification: openApiSpecification
    apiVersion: apiVersion
    // policyDocument: loadTextContent('./petstore/petstore-api.xml')
  }
  dependsOn: [
    apimService
  ]
}
