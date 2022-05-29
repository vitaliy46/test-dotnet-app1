#Контейнер будеть работать на оптимизированном образе от Microsoft
FROM mcr.microsoft.com/dotnet/core/sdk

ARG COMMIT_ID
ENV COMMIT_ID=${COMMIT_ID}

ENV ASPNETCORE_ENVIRONMENT=test

#Исполнение команды в момент сборки образа (создаём папку в контейнере)
RUN mkdir /app

#РќРµ СЂР°Р±РѕС‚Р°РµС‚ СѓСЃС‚Р°РЅРІРѕРєР° РїР°РєРµС‚РѕРІ, РІС‹РґР°С‘С‚ РѕС€РёР±РєСѓ, РЅР°РґРѕ РїРѕС‡РёРЅРёС‚СЊ
#RUN apt-get update && apt-get install -y nano && apt-get install --assume-yes apt-utils

#Команда WORKDIR указывает директорию, из которой будет выполняться команда CMD
WORKDIR /app

#Копируем файлы в контейнер (пути относительные файла dockerfile!!!)
COPY ./aspnet-core/src/modules/Investors/Kis.Investors.WebHost/bin/Test/netcoreapp2.2/publish /app

#Выставляем порт наружу контейнера
EXPOSE 21021

#Устанавливает конкретное приложение по умолчанию, которое используется каждый раз в момент построения контейнера с помощью образа
ENTRYPOINT ["dotnet", "Kis.Investors.WebHost.dll"]


