FROM mcr.microsoft.com/azure-cli

COPY . .

RUN ["chmod", "+x", "./storage-setup-entrypoint.sh"]

ENTRYPOINT ["./storage-setup-entrypoint.sh"]
