# Source: https://stackoverflow.com/a/62060315
# Generate self-signed certificate to be used by IdentityServer.
# When using localhost - API cannot see the IdentityServer from within the docker-compose'd network.
# You have to run this script as Administrator (open Powershell by right click -> Run as Administrator).

$ErrorActionPreference = "Stop"

$rootCN = "IdentityServerDockerDemoRootCert"
$identityServerCNs = "identity-server", "localhost"
$webApiCNs = "web-api", "localhost"
$dataequipmentCNs = "dataequipment", "localhost"
$datascheduleCNs = "dataschedule", "localhost"
$dataclientCNs = "dataclient", "localhost"
$apigatewayCNs = "apigateway", "localhost"

$alreadyExistingCertsRoot = Get-ChildItem -Path Cert:\LocalMachine\My -Recurse | Where-Object {$_.Subject -eq "CN=$rootCN"}
$alreadyExistingCertsIdentityServer = Get-ChildItem -Path Cert:\LocalMachine\My -Recurse | Where-Object {$_.Subject -eq ("CN={0}" -f $identityServerCNs[0])}
$alreadyExistingCertsApi = Get-ChildItem -Path Cert:\LocalMachine\My -Recurse | Where-Object {$_.Subject -eq ("CN={0}" -f $webApiCNs[0])}
$alreadyExistingCertsdataequipment = Get-ChildItem -Path Cert:\LocalMachine\My -Recurse | Where-Object {$_.Subject -eq ("CN={0}" -f $dataequipmentCNs[0])}
$alreadyExistingCertsdataschedule = Get-ChildItem -Path Cert:\LocalMachine\My -Recurse | Where-Object {$_.Subject -eq ("CN={0}" -f $dataequipmentCNs[0])}
$alreadyExistingCertsdataclient = Get-ChildItem -Path Cert:\LocalMachine\My -Recurse | Where-Object {$_.Subject -eq ("CN={0}" -f $dataclientCNs[0])}
$alreadyExistingCertsapigateway = Get-ChildItem -Path Cert:\LocalMachine\My -Recurse | Where-Object {$_.Subject -eq ("CN={0}" -f $apigatewayCNs[0])}

if ($alreadyExistingCertsRoot.Count -eq 1) {
    Write-Output "Skipping creating Root CA certificate as it already exists."
    $testRootCA = [Microsoft.CertificateServices.Commands.Certificate] $alreadyExistingCertsRoot[0]
} else {
    $testRootCA = New-SelfSignedCertificate -Subject $rootCN -KeyUsageProperty Sign -KeyUsage CertSign -CertStoreLocation Cert:\LocalMachine\My
}

if ($alreadyExistingCertsIdentityServer.Count -eq 1) {
    Write-Output "Skipping creating Identity Server certificate as it already exists."
    $identityServerCert = [Microsoft.CertificateServices.Commands.Certificate] $alreadyExistingCertsIdentityServer[0]
} else {
    # Create a SAN cert for both identity-server and localhost.
    $identityServerCert = New-SelfSignedCertificate -DnsName $identityServerCNs -Signer $testRootCA -CertStoreLocation Cert:\LocalMachine\My
}

if ($alreadyExistingCertsApi.Count -eq 1) {
    Write-Output "Skipping creating API certificate as it already exists."
    $webApiCert = [Microsoft.CertificateServices.Commands.Certificate] $alreadyExistingCertsApi[0]
} else {
    # Create a SAN cert for both web-api and localhost.
    $webApiCert = New-SelfSignedCertificate -DnsName $webApiCNs -Signer $testRootCA -CertStoreLocation Cert:\LocalMachine\My
}

if ($alreadyExistingCertsdataequipment.Count -eq 1) {
    Write-Output "Skipping creating DATAEQUIPMENT certificate as it already exists."
    $dataequipmentCert = [Microsoft.CertificateServices.Commands.Certificate] $alreadyExistingCertsdataequipment[0]
} else {
    # Create a SAN cert for both web-api and localhost.
    $dataequipmentCert = New-SelfSignedCertificate -DnsName $webApiCNs -Signer $testRootCA -CertStoreLocation Cert:\LocalMachine\My
}

if ($alreadyExistingCertsdataschedule.Count -eq 1) {
    Write-Output "Skipping creating DATASCHEDULE certificate as it already exists."
    $datascheduleCert = [Microsoft.CertificateServices.Commands.Certificate] $alreadyExistingCertsdataschedule[0]
} else {
    # Create a SAN cert for both web-api and localhost.
    $datascheduleCert = New-SelfSignedCertificate -DnsName $datascheduleCNs -Signer $testRootCA -CertStoreLocation Cert:\LocalMachine\My
}

if ($alreadyExistingCertsdataclient.Count -eq 1) {
    Write-Output "Skipping creating DATACLIENT certificate as it already exists."
    $dataclientCert = [Microsoft.CertificateServices.Commands.Certificate] $alreadyExistingCertsdataclient[0]
} else {
    # Create a SAN cert for both web-api and localhost.
    $dataclientCert = New-SelfSignedCertificate -DnsName $dataclientCNs -Signer $testRootCA -CertStoreLocation Cert:\LocalMachine\My
}

if ($alreadyExistingCertsapigateway.Count -eq 1) {
    Write-Output "Skipping creating APIGATEWAY certificate as it already exists."
    $apigatewayCert = [Microsoft.CertificateServices.Commands.Certificate] $alreadyExistingCertsapigateway[0]
} else {
    # Create a SAN cert for both web-api and localhost.
    $apigatewayCert = New-SelfSignedCertificate -DnsName $apigatewayCNs -Signer $testRootCA -CertStoreLocation Cert:\LocalMachine\My
}

# Export it for docker container to pick up later.
$password = ConvertTo-SecureString -String "password" -Force -AsPlainText

$rootCertPathPfx = "certs"
$identityServerCertPath = "IdentityServer/certs"
$webApiCertPath = "Api/certs"
$dataequipmentCertPath = "Salka.Data.Equipment/certs"
$datascheduleCertPath = "Salka.Data.Schedule/certs"
$dataclientCertPath = "Salka.Data.Client/certs"
$apigatewayCertPath = "Salka.ApiGateway/certs"

[System.IO.Directory]::CreateDirectory($rootCertPathPfx) | Out-Null
[System.IO.Directory]::CreateDirectory($identityServerCertPath) | Out-Null
[System.IO.Directory]::CreateDirectory($webApiCertPath) | Out-Null
[System.IO.Directory]::CreateDirectory($dataequipmentCertPath) | Out-Null
[System.IO.Directory]::CreateDirectory($datascheduleCertPath) | Out-Null
[System.IO.Directory]::CreateDirectory($dataclientCertPath) | Out-Null
[System.IO.Directory]::CreateDirectory($apigatewayCertPath) | Out-Null

Export-PfxCertificate -Cert $testRootCA -FilePath "$rootCertPathPfx/aspnetapp-root-cert.pfx" -Password $password | Out-Null
Export-PfxCertificate -Cert $identityServerCert -FilePath "$identityServerCertPath/aspnetapp-identity-server.pfx" -Password $password | Out-Null
Export-PfxCertificate -Cert $webApiCert -FilePath "$webApiCertPath/aspnetapp-web-api.pfx" -Password $password | Out-Null
Export-PfxCertificate -Cert $dataequipmentCert -FilePath "$dataequipmentCertPath/aspnetapp-dataequipment.pfx" -Password $password | Out-Null
Export-PfxCertificate -Cert $datascheduleCert -FilePath "$datascheduleCertPath/aspnetapp-dataschedule.pfx" -Password $password | Out-Null
Export-PfxCertificate -Cert $dataclientCert -FilePath "$dataclientCertPath/aspnetapp-dataclient.pfx" -Password $password | Out-Null
Export-PfxCertificate -Cert $apigatewayCert -FilePath "$apigatewayCertPath/aspnetapp-apigateway.pfx" -Password $password | Out-Null

# Export .cer to be converted to .crt to be trusted within the Docker container.
$rootCertPathCer = "certs/aspnetapp-root-cert.cer"
Export-Certificate -Cert $testRootCA -FilePath $rootCertPathCer -Type CERT | Out-Null

# Trust it on your host machine.
$store = New-Object System.Security.Cryptography.X509Certificates.X509Store "Root","LocalMachine"
$store.Open("ReadWrite")

$rootCertAlreadyTrusted = ($store.Certificates | Where-Object {$_.Subject -eq "CN=$rootCN"} | Measure-Object).Count -eq 1

if ($rootCertAlreadyTrusted -eq $false) {
    Write-Output "Adding the root CA certificate to the trust store."
    $store.Add($testRootCA)
}

$store.Close()