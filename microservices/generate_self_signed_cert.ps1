# Source: https://stackoverflow.com/a/62060315
# Generate self-signed certificate to be used by IdentityServer.
# When using localhost - API cannot see the IdentityServer from within the docker-compose'd network.
# You have to run this script as Administrator (open Powershell by right click -> Run as Administrator).

$ErrorActionPreference = "Stop"

$rootCN = "IdentityServerDockerDemoRootCert"
$identityServerCNs = "identity-server", "localhost"
$apiGatewayCNs = "apigateway", "localhost"
$dataClientCNs = "dataclient", "localhost"
$dataEquipmentCNs = "dataequipment", "localhost"
$dataScheduleCNs = "dataschedule", "localhost"

$testRootCA = New-SelfSignedCertificate -Subject $rootCN -KeyUsageProperty Sign -KeyUsage CertSign -CertStoreLocation Cert:\LocalMachine\My
$identityServerCert = New-SelfSignedCertificate -DnsName $identityServerCNs -Signer $testRootCA -CertStoreLocation Cert:\LocalMachine\My
$apiGatewayCert = New-SelfSignedCertificate -DnsName $apiGatewayCNs -Signer $testRootCA -CertStoreLocation Cert:\LocalMachine\My
$dataClientCert = New-SelfSignedCertificate -DnsName $dataClientCNs -Signer $testRootCA -CertStoreLocation Cert:\LocalMachine\My
$dataEquipmentCert = New-SelfSignedCertificate -DnsName $dataEquipmentCNs -Signer $testRootCA -CertStoreLocation Cert:\LocalMachine\My
$dataScheduleCert = New-SelfSignedCertificate -DnsName $dataScheduleCNs -Signer $testRootCA -CertStoreLocation Cert:\LocalMachine\My

$password = ConvertTo-SecureString -String "password" -Force -AsPlainText

$rootCertPathPfx = "certs"
$identityServerCertPath = "Salka.IdentityServer.Docker/Salka.IdentityServer.Docker/certs"
$apiGatewayCertPath = "Salka.ApiGateway/Salka.ApiGateway/certs"
$dataClientCertPath = "Salka.Data.Client/Salka.Data.Client/certs"
$dataEquipmentCertPath = "Salka.Data.Equipment/Salka.Data.Equipment/certs"
$dataScheduleCertPath = "Salka.Data.Schedule/Salka.Data.Schedule/certs"

Export-PfxCertificate -Cert $testRootCA -FilePath "$rootCertPathPfx/aspnetapp-root-cert.pfx" -Password $password | Out-Null
Export-PfxCertificate -Cert $identityServerCert -FilePath "$identityServerCertPath/aspnetapp-identity-server.pfx" -Password $password | Out-Null
Export-PfxCertificate -Cert $apiGatewayCert -FilePath "$apiGatewayCertPath/aspnetapp-apigateway.pfx" -Password $password | Out-Null
Export-PfxCertificate -Cert $dataClientCert -FilePath "$dataClientCertPath/aspnetapp-dataclient.pfx" -Password $password | Out-Null
Export-PfxCertificate -Cert $dataEquipmentCert -FilePath "$dataEquipmentCertPath/aspnetapp-dataequipment.pfx" -Password $password | Out-Null
Export-PfxCertificate -Cert $dataScheduleCert -FilePath "$dataScheduleCertPath/aspnetapp-dataschedule.pfx" -Password $password | Out-Null

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