# # Стъпка 1: Използваме официалния .NET SDK за билд
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# WORKDIR /app

# # Копираме .csproj и възстановяваме зависимостите
# COPY *.sln ./
# COPY MiniLibrary/*.csproj ./MiniLibrary/
# RUN dotnet restore

# # Копираме останалия код и билдваме приложението
# COPY MiniLibrary/. ./MiniLibrary/
# WORKDIR /app/MiniLibrary
# RUN dotnet publish -c Release -o /app/publish

# # Стъпка 2: Използваме по-лек runtime за финалния контейнер
# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
# WORKDIR /app
# COPY --from=build /app/publish .

# # Портът по подразбиране (можеш да смениш ако ползваш друг)
# EXPOSE 8080
# ENTRYPOINT ["dotnet", "MiniLibrary.dll"]




# # Този файл описва как се създава Docker образ (image) за твоето ASP.NET приложение.

# # 	•	Изтегля нужните .NET SDK и runtime образи
# # 	•	Копира твоя проект вътре в контейнера
# # 	•	Компилира (build-ва) приложението
# # 	•	Публикува го и го подготвя за стартиране
# # 	•	Казва какво да се изпълни (entrypoint)