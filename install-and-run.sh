# Install dot net if it is not installed
echo "Instalando .net (c#) en ubuntu, si no está instalado"
echo "Usando un script de instalación de MS."
echo "La descarga puede tardar un ratito."
./dotnet-install.sh -c LTS

echo ".net se encuentra en $HOME/.dotnet"

# Correr el proyecto tal cual
$HOME/.dotnet/dotnet run --project Tec.Compis.ConsoleApp