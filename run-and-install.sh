# Install dot net if it is not installed
echo "Instalando sdk .net (para el compilador de c#) en ubuntu si no está instalado."
echo "Usando un script de instalación de Microsoft."
echo "La descarga puede tardar un ratito."
./dotnet-install.sh -c LTS

echo ".net se encuentra en $HOME/.dotnet"

# Correr el proyecto tal cual

dll=Tec.Compis.ConsoleApp/bin/Debug/net6.0/Tec.Compis.ConsoleApp.dll

if [ ! -f "$dll" ]; then
    echo "Programa no compilado. Compilando y ejecutando"
    echo "--------------------------------------------------------"
    $HOME/.dotnet/dotnet run --project Tec.Compis.ConsoleApp
else
    echo "Programa compilado. Solamente ejecutar dotnet $dll."
    echo "--------------------------------------------------------"
    $HOME/.dotnet/dotnet $dll
fi

