namespace NHS.CohortManager.Tests.CaasIntegrationTests;

using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHS.Screening.ReceiveCaasFile;
using Common;

[TestClass]
public class ReceiveCaasFileTests
{
    private Mock<ILogger<ReceiveCaasFile>> mockLogger;
    private Mock<ICallFunction> mockICallFunction;
    private Mock<IFileReader> mockIFileReader;
    private ReceiveCaasFile receiveCaasFileInstance;
    private string validCsvData;
    private string invalidCsvData;
    private string expectedJson;
    private string blobName;

    [TestInitialize]
    public void Setup()
    {
        mockLogger = new Mock<ILogger<ReceiveCaasFile>>();
        mockICallFunction = new Mock<ICallFunction>();
        mockIFileReader = new Mock<IFileReader>();
        receiveCaasFileInstance = new ReceiveCaasFile(mockLogger.Object, mockICallFunction.Object);
        blobName = "testBlob";


        validCsvData = "Record Type,Change Time Stamp,Serial Change Number,NHS Number,Superseded by NHS number,Primary Care Provider ,Primary Care Provider Business Effective From Date,Current Posting,Current Posting Business Effective From Date,Previous Posting,Previous Posting Business Effective To Date,Name Prefix,Given Name ,Other Given Name(s) ,Family Name ,Previous Family Name ,Date of Birth,Gender,Address line 1,Address line 2,Address line 3,Address line 4,Address line 5,Postcode,PAF key,Usual Address Business Effective From Date,Reason for Removal,Reason for Removal Business Effective From Date,Date of Death,Death Status,Telephone Number (Home),Telephone Number (Home) Business Effective From Date,Telephone Number (Mobile),Telephone Number (Mobile) Business Effective From Date,E-mail address (Home),E-mail address (Home) Business Effective From Date,Preferred Language,Interpreter required,Invalid Flag,Record Identifier,Change Reason Code\n" +
        "New,20240524153000,1,1111111111,,B83006,20240410,Manchester,20240410,Edinburgh,20230410,Mr,Joe,,Bloggs,,19711221,1,HEXAGON HOUSE,PYNES HILL,RYDON LANE,EXETER,DEVON,BV3 9ZA,1234,,,,,,,,,,,,English,0,0,1,\n" +
        "Amended,20240524153000,2,2222222222,,D81026,20240411,Liverpool,20240411,Birmingham,20230411,Mrs,Jane,,Doe,,19680801,2,1 New Road,SOLIHULL,West Midlands,,,B91 3DL,4321,,,,20240501,1,,,,,,,English,0,0,2,\n" +
        "Removed,20240524153000,3,3333333333,,L83137,20240412,London,20240411,Swansea,20230412,Dr,John,,Jones,,19501201,1,100,spen lane,Leeds,,,LS16 5BR,5555,,,,,,,,,,,,French,1,0,3";

        invalidCsvData = "invalid data";
    }

    [TestMethod]
    public async Task Run_SuccessfulParseAndSendDataWithValidInput_SuccessfulSendToFunctionWithResponse()
    {
        // Arrange
        byte[] csvDataBytes = Encoding.UTF8.GetBytes(validCsvData);
        var memoryStream = new MemoryStream(csvDataBytes);
        mockIFileReader.Setup(fileReader => fileReader.ReadStream(It.IsAny<Stream>()))
                        .Returns(() => new StreamReader(memoryStream));

        mockICallFunction.Setup(callFunction => callFunction.SendPost(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
        expectedJson = "{\"null\":[{\"RecordType\":\"New\",\"ChangeTimeStamp\":\"2024-05-24T15:30:00\",\"SerialChangeNumber\":1,\"NHSId\":1111111111,\"SupersededByNhsNumber\":null,\"PrimaryCareProvider\":\"B83006\",\"PrimaryCareProviderEffectiveFromDate\":\"2024-04-10T00:00:00\",\"CurrentPosting\":\"Manchester\",\"CurrentPostingEffectiveFromDate\":\"2024-04-10 00:00:00\",\"PreviousPosting\":\"Edinburgh\",\"PreviousPostingEffectiveFromDate\":\"2023-04-10 00:00:00\",\"NamePrefix\":\"Mr\",\"FirstName\":\"Joe\",\"OtherGivenNames\":null,\"Surname\":\"Bloggs\",\"PreviousSurname\":null,\"DateOfBirth\":\"1971-12-21 00:00:00\",\"Gender\":1,\"AddressLine1\":\"HEXAGON HOUSE\",\"AddressLine2\":\"PYNES HILL\",\"AddressLine3\":\"RYDON LANE\",\"AddressLine4\":\"EXETER\",\"AddressLine5\":\"DEVON\",\"Postcode\":\"BV3 9ZA\",\"PafKey\":\"1234\",\"UsualAddressEffectiveFromDate\":null,\"ReasonForRemoval\":null,\"ReasonForRemovalEffectiveFromDate\":null,\"DateOfDeath\":null,\"DeathStatus\":null,\"TelephoneNumber\":null,\"TelephoneNumberEffectiveFromDate\":null,\"MobileNumber\":null,\"MobileNumberEffectiveFromDate\":null,\"EmailAddress\":null,\"EmailAddressEffectiveFromDate\":null,\"PreferredLanguage\":\"English\",\"IsInterpreterRequired\":false,\"InvalidFlag\":false,\"RecordIdentifier\":\"1\",\"ChangeReasonCode\":null},{\"RecordType\":\"Amended\",\"ChangeTimeStamp\":\"2024-05-24T15:30:00\",\"SerialChangeNumber\":2,\"NHSId\":2222222222,\"SupersededByNhsNumber\":null,\"PrimaryCareProvider\":\"D81026\",\"PrimaryCareProviderEffectiveFromDate\":\"2024-04-11T00:00:00\",\"CurrentPosting\":\"Liverpool\",\"CurrentPostingEffectiveFromDate\":\"2024-04-11 00:00:00\",\"PreviousPosting\":\"Birmingham\",\"PreviousPostingEffectiveFromDate\":\"2023-04-11 00:00:00\",\"NamePrefix\":\"Mrs\",\"FirstName\":\"Jane\",\"OtherGivenNames\":null,\"Surname\":\"Doe\",\"PreviousSurname\":null,\"DateOfBirth\":\"1968-08-01 00:00:00\",\"Gender\":2,\"AddressLine1\":\"1 New Road\",\"AddressLine2\":\"SOLIHULL\",\"AddressLine3\":\"West Midlands\",\"AddressLine4\":null,\"AddressLine5\":null,\"Postcode\":\"B91 3DL\",\"PafKey\":\"4321\",\"UsualAddressEffectiveFromDate\":null,\"ReasonForRemoval\":null,\"ReasonForRemovalEffectiveFromDate\":null,\"DateOfDeath\":\"2024-05-01 00:00:00\",\"DeathStatus\":1,\"TelephoneNumber\":null,\"TelephoneNumberEffectiveFromDate\":null,\"MobileNumber\":null,\"MobileNumberEffectiveFromDate\":null,\"EmailAddress\":null,\"EmailAddressEffectiveFromDate\":null,\"PreferredLanguage\":\"English\",\"IsInterpreterRequired\":false,\"InvalidFlag\":false,\"RecordIdentifier\":\"2\",\"ChangeReasonCode\":null},{\"RecordType\":\"Removed\",\"ChangeTimeStamp\":\"2024-05-24T15:30:00\",\"SerialChangeNumber\":3,\"NHSId\":3333333333,\"SupersededByNhsNumber\":null,\"PrimaryCareProvider\":\"L83137\",\"PrimaryCareProviderEffectiveFromDate\":\"2024-04-12T00:00:00\",\"CurrentPosting\":\"London\",\"CurrentPostingEffectiveFromDate\":\"2024-04-12 00:00:00\",\"PreviousPosting\":\"Swansea\",\"PreviousPostingEffectiveFromDate\":\"2023-04-12 00:00:00\",\"NamePrefix\":\"Dr\",\"FirstName\":\"John\",\"OtherGivenNames\":null,\"Surname\":\"Jones\",\"PreviousSurname\":null,\"DateOfBirth\":\"1950-12-01 00:00:00\",\"Gender\":1,\"AddressLine1\":\"100\",\"AddressLine2\":\"spen lane\",\"AddressLine3\":\"Leeds\",\"AddressLine4\":null,\"AddressLine5\":null,\"Postcode\":\"LS16 5BR\",\"PafKey\":\"5555\",\"UsualAddressEffectiveFromDate\":null,\"ReasonForRemoval\":null,\"ReasonForRemovalEffectiveFromDate\":null,\"DateOfDeath\":null,\"DeathStatus\":null,\"TelephoneNumber\":null,\"TelephoneNumberEffectiveFromDate\":null,\"MobileNumber\":null,\"MobileNumberEffectiveFromDate\":null,\"EmailAddress\":null,\"EmailAddressEffectiveFromDate\":null,\"PreferredLanguage\":\"French\",\"IsInterpreterRequired\":true,\"InvalidFlag\":false,\"RecordIdentifier\":\"3\",\"ChangeReasonCode\":null}]}";

        // Act
        await receiveCaasFileInstance.Run(memoryStream, blobName);

        // Assert
        mockLogger.Verify(
            m => m.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ),
            Times.AtLeastOnce,
            "No logging received."
        );

        mockICallFunction.Verify(
            x => x.SendPost(It.IsAny<string>(),
          //  It.Is<string>(json => json == expectedJson)),
          It.IsAny<string>()),
            Times.Once);
    }

    [TestMethod]
    public async Task Run_SuccessfulParseWithInvalidInput_FailsAndLogsError()
    {
        // Arrange
        byte[] csvDataBytes = Encoding.UTF8.GetBytes(invalidCsvData);
        var memoryStream = new MemoryStream(csvDataBytes);
        mockIFileReader.Setup(fileReader => fileReader.ReadStream(It.IsAny<Stream>()))
                        .Returns(() => new StreamReader(memoryStream));

        mockICallFunction.Setup(callFunction => callFunction.SendPost(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

        // Act
        await receiveCaasFileInstance.Run(memoryStream, blobName);

        //Assert
        mockLogger.Verify(
                x => x.Log(It.Is<LogLevel>(l => l == LogLevel.Error),
                            It.IsAny<EventId>(),
                            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Created 0 Objects")),
                            It.IsAny<Exception>(),
                            It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                            Times.Once);

        mockLogger.Verify(
                x => x.Log(It.Is<LogLevel>(l => l == LogLevel.Error),
                            It.IsAny<EventId>(),
                            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Failed to create 0 Objects")),
                            It.IsAny<Exception>(),
                            It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                            Times.Once);
    }

    [TestMethod]
    public async Task Run_UnsuccessfulParseAndSendDataWithValidInput_FailsAndLogsError()
    {
        // Arrange
        byte[] csvDataBytes = Encoding.UTF8.GetBytes(validCsvData);
        var memoryStream = new MemoryStream(csvDataBytes);
        mockIFileReader.Setup(fileReader => fileReader.ReadStream(It.IsAny<Stream>()))
                        .Throws(new Exception("Failed to read the incoming file"));
        mockICallFunction.Setup(callFunction => callFunction.SendPost(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

        // Act
        await receiveCaasFileInstance.Run(memoryStream, blobName);

        // Assert
        mockLogger.Verify(l => l.Log(LogLevel.Information,
                                        It.IsAny<EventId>(),
                                        It.IsAny<It.IsAnyType>(),
                                        It.IsAny<Exception>(),
                                        It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                                        Times.AtLeastOnce());
    }
}
