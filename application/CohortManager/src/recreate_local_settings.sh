#!/bin/bash
mkdir -p "..//src/AzureSimulator/ServicePlanningEventGrid/ServicePlanningEventGridFunction"
cat > "..//src/AzureSimulator/ServicePlanningEventGrid/ServicePlanningEventGridFunction/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DB_CONNECTION_STRING": "Server=tcp:dev-dtos-db-server.database.windows.net,1433;Initial Catalog=DToSDB;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication='Active Directory Default';",
        "CREATE_PARTICIPANT_TOPIC": "sp-topic-createParticipant"
    }
}

EOF
mkdir -p "..//src/Functions/ScreeningValidationService/StaticValidation/bin/output"
cat > "..//src/Functions/ScreeningValidationService/StaticValidation/bin/output/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "CreateValidationExceptionURL": "http://localhost:7073/api/CreateValidationException"
  },
  "Host": {
    "LocalHttpPort": 7071
  }
}

EOF
mkdir -p "..//src/Functions/ScreeningValidationService/StaticValidation/bin/Debug/net8.0"
cat > "..//src/Functions/ScreeningValidationService/StaticValidation/bin/Debug/net8.0/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "CreateValidationExceptionURL": "http://localhost:7073/api/CreateValidationException"
  },
  "Host": {
    "LocalHttpPort": 7071
  }
}

EOF
mkdir -p "..//src/Functions/ScreeningValidationService/StaticValidation"
cat > "..//src/Functions/ScreeningValidationService/StaticValidation/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "CreateValidationExceptionURL": "http://localhost:7073/api/CreateValidationException"
  },
  "Host": {
    "LocalHttpPort": 7071
  }
}

EOF
mkdir -p "..//src/Functions/ScreeningValidationService/LookupValidation/bin/output"
cat > "..//src/Functions/ScreeningValidationService/LookupValidation/bin/output/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "CreateValidationExceptionURL": "http://localhost:7073/api/CreateValidationException"
  },
  "Host": {
    "LocalHttpPort": 7072
  }
}

EOF
mkdir -p "..//src/Functions/ScreeningValidationService/LookupValidation/bin/Debug/net8.0"
cat > "..//src/Functions/ScreeningValidationService/LookupValidation/bin/Debug/net8.0/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "CreateValidationExceptionURL": "http://localhost:7073/api/CreateValidationException"
  },
  "Host": {
    "LocalHttpPort": 7072
  }
}

EOF
mkdir -p "..//src/Functions/ScreeningValidationService/LookupValidation"
cat > "..//src/Functions/ScreeningValidationService/LookupValidation/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "CreateValidationExceptionURL": "http://localhost:7073/api/CreateValidationException"
  },
  "Host": {
    "LocalHttpPort": 7072
  }
}

EOF
mkdir -p "..//src/Functions/CaasIntegration/processCaasFile/bin/output"
cat > "..//src/Functions/CaasIntegration/processCaasFile/bin/output/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "PMSAddParticipant": "http://localhost:7062/api/addParticipant",
        "PMSRemoveParticipant": "http://localhost:7063/api/RemoveParticipant",
        "PMSUpdateParticipant": "http://localhost:7065/api/updateParticipant",
        "DemographicURI": "http://localhost:7081/api/DemographicDataFunction"
    },
    "Host": {
      "LocalHttpPort": 7061
    }
}


EOF
mkdir -p "..//src/Functions/CaasIntegration/processCaasFile/bin/Debug/net8.0"
cat > "..//src/Functions/CaasIntegration/processCaasFile/bin/Debug/net8.0/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "PMSAddParticipant": "http://localhost:7062/api/addParticipant",
        "PMSRemoveParticipant": "http://localhost:7063/api/RemoveParticipant",
        "PMSUpdateParticipant": "http://localhost:7065/api/updateParticipant",
        "DemographicURI": "http://localhost:7081/api/DemographicDataFunction"
    },
    "Host": {
      "LocalHttpPort": 7061
    }
}


EOF
mkdir -p "..//src/Functions/CaasIntegration/processCaasFile"
cat > "..//src/Functions/CaasIntegration/processCaasFile/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "PMSAddParticipant": "http://localhost:7062/api/addParticipant",
        "PMSRemoveParticipant": "http://localhost:7063/api/RemoveParticipant",
        "PMSUpdateParticipant": "http://localhost:7065/api/updateParticipant",
        "DemographicURI": "http://localhost:7081/api/DemographicDataFunction"
    },
    "Host": {
      "LocalHttpPort": 7061
    }
}


EOF
mkdir -p "..//src/Functions/CaasIntegration/receiveCaasFile/bin/output"
cat > "..//src/Functions/CaasIntegration/receiveCaasFile/bin/output/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
      "AzureWebJobsStorage": "UseDevelopmentStorage=true",
      "AzureWebJobsSecretStorageType": "files",
      "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
      "caasfolder_STORAGE": "UseDevelopmentStorage=true",
      "targetFunction": "http://localhost:7061/api/processCaasFile",
      "AzureWebJobsSecretStorageType": "files"
    },
    "Host": {
      "LocalHttpPort": 7060
    }
}



EOF
mkdir -p "..//src/Functions/CaasIntegration/receiveCaasFile/bin/Debug/net8.0"
cat > "..//src/Functions/CaasIntegration/receiveCaasFile/bin/Debug/net8.0/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
      "AzureWebJobsStorage": "UseDevelopmentStorage=true",
      "AzureWebJobsSecretStorageType": "files",
      "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
      "caasfolder_STORAGE": "UseDevelopmentStorage=true",
      "targetFunction": "http://localhost:7061/api/processCaasFile",
      "AzureWebJobsSecretStorageType": "files"
    },
    "Host": {
      "LocalHttpPort": 7060
    }
}



EOF
mkdir -p "..//src/Functions/CaasIntegration/receiveCaasFile"
cat > "..//src/Functions/CaasIntegration/receiveCaasFile/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
      "AzureWebJobsStorage": "UseDevelopmentStorage=true",
      "AzureWebJobsSecretStorageType": "files",
      "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
      "caasfolder_STORAGE": "UseDevelopmentStorage=true",
      "targetFunction": "http://localhost:7061/api/processCaasFile",
      "AzureWebJobsSecretStorageType": "files"
    },
    "Host": {
      "LocalHttpPort": 7060
    }
}



EOF
mkdir -p "..//src/Functions/ParticipantManagementServices/updateParticipant/bin/output"
cat > "..//src/Functions/ParticipantManagementServices/updateParticipant/bin/output/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "UpdateParticipant": "http://localhost:7069/api/updateParticipantDetails",
        "DemographicURIGet": "http://localhost:7081/api/DemographicDataManagement",
        "StaticValidationURL": "http://localhost:7071/api/StaticValidation"
    },
    "Host": {
      "LocalHttpPort": 7065
    }
}


EOF
mkdir -p "..//src/Functions/ParticipantManagementServices/updateParticipant/bin/Debug/net8.0"
cat > "..//src/Functions/ParticipantManagementServices/updateParticipant/bin/Debug/net8.0/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "UpdateParticipant": "http://localhost:7069/api/updateParticipantDetails",
        "DemographicURIGet": "http://localhost:7081/api/DemographicDataManagement",
        "StaticValidationURL": "http://localhost:7071/api/StaticValidation"
    },
    "Host": {
      "LocalHttpPort": 7065
    }
}


EOF
mkdir -p "..//src/Functions/ParticipantManagementServices/updateParticipant"
cat > "..//src/Functions/ParticipantManagementServices/updateParticipant/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "UpdateParticipant": "http://localhost:7069/api/updateParticipantDetails",
        "DemographicURIGet": "http://localhost:7081/api/DemographicDataManagement",
        "StaticValidationURL": "http://localhost:7071/api/StaticValidation"
    },
    "Host": {
      "LocalHttpPort": 7065
    }
}


EOF
mkdir -p "..//src/Functions/ParticipantManagementServices/addParticipant/bin/output"
cat > "..//src/Functions/ParticipantManagementServices/addParticipant/bin/output/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DSaddParticipant": "http://localhost:7066/api/createParticipant",
        "DSmarkParticipantAsEligible": "http://localhost:7067/api/markParticipantAsEligible",
        "DemographicURIGet": "http://localhost:7081/api/DemographicDataManagement"
    },
    "Host": {
      "LocalHttpPort": 7062
    }
}


EOF
mkdir -p "..//src/Functions/ParticipantManagementServices/addParticipant/bin/Debug/net8.0"
cat > "..//src/Functions/ParticipantManagementServices/addParticipant/bin/Debug/net8.0/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DSaddParticipant": "http://localhost:7066/api/createParticipant",
        "DSmarkParticipantAsEligible": "http://localhost:7067/api/markParticipantAsEligible",
        "DemographicURIGet": "http://localhost:7081/api/DemographicDataManagement"
    },
    "Host": {
      "LocalHttpPort": 7062
    }
}


EOF
mkdir -p "..//src/Functions/ParticipantManagementServices/addParticipant"
cat > "..//src/Functions/ParticipantManagementServices/addParticipant/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DSaddParticipant": "http://localhost:7066/api/createParticipant",
        "DSmarkParticipantAsEligible": "http://localhost:7067/api/markParticipantAsEligible",
        "DemographicURIGet": "http://localhost:7081/api/DemographicDataManagement"
    },
    "Host": {
      "LocalHttpPort": 7062
    }
}


EOF
mkdir -p "..//src/Functions/ParticipantManagementServices/updateEligibility/bin/output"
cat > "..//src/Functions/ParticipantManagementServices/updateEligibility/bin/output/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DSmarkParticipantAsIneligible": "http://localhost:7068/api/markParticipantAsEIneligible",
        "DemographicURIGet": "http://localhost:7081/api/DemographicDataManagement"
    },
    "Host": {
      "LocalHttpPort": 7064
    }
}


EOF
mkdir -p "..//src/Functions/ParticipantManagementServices/updateEligibility/bin/Debug/net8.0"
cat > "..//src/Functions/ParticipantManagementServices/updateEligibility/bin/Debug/net8.0/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DSmarkParticipantAsIneligible": "http://localhost:7068/api/markParticipantAsEIneligible",
        "DemographicURIGet": "http://localhost:7081/api/DemographicDataManagement"
    },
    "Host": {
      "LocalHttpPort": 7064
    }
}


EOF
mkdir -p "..//src/Functions/ParticipantManagementServices/updateEligibility"
cat > "..//src/Functions/ParticipantManagementServices/updateEligibility/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DSmarkParticipantAsIneligible": "http://localhost:7068/api/markParticipantAsEIneligible",
        "DemographicURIGet": "http://localhost:7081/api/DemographicDataManagement"
    },
    "Host": {
      "LocalHttpPort": 7064
    }
}


EOF
mkdir -p "..//src/Functions/ParticipantManagementServices/RemoveParticipant/bin/output"
cat > "..//src/Functions/ParticipantManagementServices/RemoveParticipant/bin/output/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True",
        "markParticipantAsIneligible": "http://localhost:7068/api/markParticipantAsIneligible",
        "DemographicURIGet": "http://localhost:7081/api/DemographicDataManagement"
    },
    "Host": {
        "LocalHttpPort": 7063
      }
}

EOF
mkdir -p "..//src/Functions/ParticipantManagementServices/RemoveParticipant/bin/Debug/net8.0"
cat > "..//src/Functions/ParticipantManagementServices/RemoveParticipant/bin/Debug/net8.0/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True",
        "markParticipantAsIneligible": "http://localhost:7068/api/markParticipantAsIneligible",
        "DemographicURIGet": "http://localhost:7081/api/DemographicDataManagement"
    },
    "Host": {
        "LocalHttpPort": 7063
      }
}

EOF
mkdir -p "..//src/Functions/ParticipantManagementServices/RemoveParticipant"
cat > "..//src/Functions/ParticipantManagementServices/RemoveParticipant/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True",
        "markParticipantAsIneligible": "http://localhost:7068/api/markParticipantAsIneligible",
        "DemographicURIGet": "http://localhost:7081/api/DemographicDataManagement"
    },
    "Host": {
        "LocalHttpPort": 7063
      }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/updateParticipantDetails/bin/output"
cat > "..//src/Functions/screeningDataServices/updateParticipantDetails/bin/output/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True",
        "LookupValidationURL": "http://localhost:7072/api/LookupValidation"
    },
    "Host": {
        "LocalHttpPort": 7069
    }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/updateParticipantDetails/bin/Debug/net8.0"
cat > "..//src/Functions/screeningDataServices/updateParticipantDetails/bin/Debug/net8.0/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True",
        "LookupValidationURL": "http://localhost:7072/api/LookupValidation"
    },
    "Host": {
        "LocalHttpPort": 7069
    }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/updateParticipantDetails"
cat > "..//src/Functions/screeningDataServices/updateParticipantDetails/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True",
        "LookupValidationURL": "http://localhost:7072/api/LookupValidation"
    },
    "Host": {
        "LocalHttpPort": 7069
    }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/GetValidationExceptions/bin/output"
cat > "..//src/Functions/screeningDataServices/GetValidationExceptions/bin/output/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "DtOsDatabaseConnectionString": "Server=localhost;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
  },
  "Host": {
    "LocalHttpPort": 7070
  }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/GetValidationExceptions/bin/Debug/net8.0"
cat > "..//src/Functions/screeningDataServices/GetValidationExceptions/bin/Debug/net8.0/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "DtOsDatabaseConnectionString": "Server=localhost;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
  },
  "Host": {
    "LocalHttpPort": 7070
  }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/GetValidationExceptions"
cat > "..//src/Functions/screeningDataServices/GetValidationExceptions/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "DtOsDatabaseConnectionString": "Server=localhost;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
  },
  "Host": {
    "LocalHttpPort": 7070
  }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/markParticipantAsEligible/bin/output"
cat > "..//src/Functions/screeningDataServices/markParticipantAsEligible/bin/output/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
      "AzureWebJobsStorage": "UseDevelopmentStorage=true",
      "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
      "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
  },
  "Host": {
      "LocalHttpPort": 7067
  }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/markParticipantAsEligible/bin/Debug/net8.0"
cat > "..//src/Functions/screeningDataServices/markParticipantAsEligible/bin/Debug/net8.0/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
      "AzureWebJobsStorage": "UseDevelopmentStorage=true",
      "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
      "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
  },
  "Host": {
      "LocalHttpPort": 7067
  }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/markParticipantAsEligible"
cat > "..//src/Functions/screeningDataServices/markParticipantAsEligible/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
      "AzureWebJobsStorage": "UseDevelopmentStorage=true",
      "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
      "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
  },
  "Host": {
      "LocalHttpPort": 7067
  }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/createParticipant/bin/output"
cat > "..//src/Functions/screeningDataServices/createParticipant/bin/output/local.settings.json" << EOF

{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "SqlConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
    },
    "Host": {
        "LocalHttpPort": 7066
      }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/createParticipant/bin/Debug/net8.0"
cat > "..//src/Functions/screeningDataServices/createParticipant/bin/Debug/net8.0/local.settings.json" << EOF

{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "SqlConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
    },
    "Host": {
        "LocalHttpPort": 7066
      }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/createParticipant"
cat > "..//src/Functions/screeningDataServices/createParticipant/local.settings.json" << EOF

{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "SqlConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
    },
    "Host": {
        "LocalHttpPort": 7066
      }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/markParticipantAsIneligible/bin/output"
cat > "..//src/Functions/screeningDataServices/markParticipantAsIneligible/bin/output/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
    },
    "Host": {
        "LocalHttpPort": 7068
      }

}

EOF
mkdir -p "..//src/Functions/screeningDataServices/markParticipantAsIneligible/bin/Debug/net8.0"
cat > "..//src/Functions/screeningDataServices/markParticipantAsIneligible/bin/Debug/net8.0/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
    },
    "Host": {
        "LocalHttpPort": 7068
      }

}

EOF
mkdir -p "..//src/Functions/screeningDataServices/markParticipantAsIneligible"
cat > "..//src/Functions/screeningDataServices/markParticipantAsIneligible/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
    },
    "Host": {
        "LocalHttpPort": 7068
      }

}

EOF
mkdir -p "..//src/Functions/screeningDataServices/DemographicDataService/bin/output"
cat > "..//src/Functions/screeningDataServices/DemographicDataService/bin/output/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
    },
    "Host": {
        "LocalHttpPort": 7080
    }

}

EOF
mkdir -p "..//src/Functions/screeningDataServices/DemographicDataService/bin/Debug/net8.0"
cat > "..//src/Functions/screeningDataServices/DemographicDataService/bin/Debug/net8.0/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
    },
    "Host": {
        "LocalHttpPort": 7080
    }

}

EOF
mkdir -p "..//src/Functions/screeningDataServices/DemographicDataService"
cat > "..//src/Functions/screeningDataServices/DemographicDataService/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
    },
    "Host": {
        "LocalHttpPort": 7080
    }

}

EOF
mkdir -p "..//src/Functions/screeningDataServices/ExceptionDataService/bin/output"
cat > "..//src/Functions/screeningDataServices/ExceptionDataService/bin/output/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
  },
  "Host": {
    "LocalHttpPort": 7070
  }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/ExceptionDataService"
cat > "..//src/Functions/screeningDataServices/ExceptionDataService/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
  },
  "Host": {
    "LocalHttpPort": 7070
  }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/CreateValidationException/bin/output"
cat > "..//src/Functions/screeningDataServices/CreateValidationException/bin/output/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "DtOsDatabaseConnectionString": "Server=localhost;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
  },
  "Host": {
    "LocalHttpPort": 7073
  }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/CreateValidationException/bin/Debug/net8.0"
cat > "..//src/Functions/screeningDataServices/CreateValidationException/bin/Debug/net8.0/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "DtOsDatabaseConnectionString": "Server=localhost;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
  },
  "Host": {
    "LocalHttpPort": 7073
  }
}

EOF
mkdir -p "..//src/Functions/screeningDataServices/CreateValidationException"
cat > "..//src/Functions/screeningDataServices/CreateValidationException/local.settings.json" << EOF
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "DtOsDatabaseConnectionString": "Server=localhost;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
  },
  "Host": {
    "LocalHttpPort": 7073
  }
}

EOF
mkdir -p "..//src/Functions/AzureSimulatorHandlers/EventGridTopics/bin/publish"
cat > "..//src/Functions/AzureSimulatorHandlers/EventGridTopics/bin/publish/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated"
    }
}
EOF
mkdir -p "..//src/Functions/AzureSimulatorHandlers/EventGridTopics"
cat > "..//src/Functions/AzureSimulatorHandlers/EventGridTopics/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated"
    }
}
EOF
mkdir -p "..//src/Functions/AzureSimulatorHandlers/EventGridLogger"
cat > "..//src/Functions/AzureSimulatorHandlers/EventGridLogger/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated"
    }
}
EOF
mkdir -p "..//src/Functions/AzureSimulatorHandlers/EventGridHandler"
cat > "..//src/Functions/AzureSimulatorHandlers/EventGridHandler/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated"
    }
}
EOF
mkdir -p "..//src/Functions/DemographicServices/DemographicDataManagementFunction/bin/output"
cat > "..//src/Functions/DemographicServices/DemographicDataManagementFunction/bin/output/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DemographicDataServiceURI": "http://localhost:7080/api/DemographicDataService",
        "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
    },
    "Host": {
      "LocalHttpPort": 7081
    }

}

EOF
mkdir -p "..//src/Functions/DemographicServices/DemographicDataManagementFunction/bin/Debug/net8.0"
cat > "..//src/Functions/DemographicServices/DemographicDataManagementFunction/bin/Debug/net8.0/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DemographicDataServiceURI": "http://localhost:7080/api/DemographicDataService",
        "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
    },
    "Host": {
      "LocalHttpPort": 7081
    }

}

EOF
mkdir -p "..//src/Functions/DemographicServices/DemographicDataManagementFunction"
cat > "..//src/Functions/DemographicServices/DemographicDataManagementFunction/local.settings.json" << EOF
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "DemographicDataServiceURI": "http://localhost:7080/api/DemographicDataService",
        "DtOsDatabaseConnectionString": "Server=localhost,1433;Database=DToSDB;User Id=SA;Password=Password!;TrustServerCertificate=True"
    },
    "Host": {
      "LocalHttpPort": 7081
    }

}
