FROM mcr.microsoft.com/mssql-tools

COPY . .

RUN ["chmod", "+x", "./db-setup-entrypoint.sh"]

ENTRYPOINT ["./db-setup-entrypoint.sh"]
