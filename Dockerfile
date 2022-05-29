#��������� ������ �������� �� ���������������� ������ �� Microsoft
FROM mcr.microsoft.com/dotnet/core/sdk

ARG COMMIT_ID
ENV COMMIT_ID=${COMMIT_ID}

ENV ASPNETCORE_ENVIRONMENT=test

#���������� ������� � ������ ������ ������ (������ ����� � ����������)
RUN mkdir /app

#Не работает устанвока пакетов, выдаёт ошибку, надо починить
#RUN apt-get update && apt-get install -y nano && apt-get install --assume-yes apt-utils

#������� WORKDIR ��������� ����������, �� ������� ����� ����������� ������� CMD
WORKDIR /app

#�������� ����� � ��������� (���� ������������� ����� dockerfile!!!)
COPY ./aspnet-core/src/modules/Investors/Kis.Investors.WebHost/bin/Test/netcoreapp2.2/publish /app

#���������� ���� ������ ����������
EXPOSE 21021

#������������� ���������� ���������� �� ���������, ������� ������������ ������ ��� � ������ ���������� ���������� � ������� ������
ENTRYPOINT ["dotnet", "Kis.Investors.WebHost.dll"]


