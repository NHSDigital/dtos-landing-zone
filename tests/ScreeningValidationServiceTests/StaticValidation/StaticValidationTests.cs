namespace NHS.CohortManager.Tests.ScreeningValidationServiceTests;

using System.Net;
using System.Text;
using System.Text.Json;
using Common;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Model;
using Moq;
using NHS.CohortManager.ScreeningValidationService;

[TestClass]
public class StaticValidationTests
{
    private readonly Mock<ILogger<StaticValidation>> _logger = new();
    private readonly Mock<ICallFunction> _callFunction = new();
    private readonly Mock<FunctionContext> _context = new();
    private readonly Mock<HttpRequestData> _request;
    private readonly ServiceCollection _serviceCollection = new();
    private readonly ParticipantCsvRecord _participantCsvRecord;
    private readonly StaticValidation _function;

    public StaticValidationTests()
    {
        Environment.SetEnvironmentVariable("CreateValidationExceptionURL", "CreateValidationExceptionURL");

        _request = new Mock<HttpRequestData>(_context.Object);

        var serviceProvider = _serviceCollection.BuildServiceProvider();

        _context.SetupProperty(c => c.InstanceServices, serviceProvider);

        _function = new StaticValidation(_logger.Object, _callFunction.Object);

        _request.Setup(r => r.CreateResponse()).Returns(() =>
        {
            var response = new Mock<HttpResponseData>(_context.Object);
            response.SetupProperty(r => r.Headers, new HttpHeadersCollection());
            response.SetupProperty(r => r.StatusCode);
            response.SetupProperty(r => r.Body, new MemoryStream());
            return response.Object;
        });

        _participantCsvRecord = new ParticipantCsvRecord()
        {
            FileName = "test",
            Participant = new Participant()
        };
    }

    [TestMethod]
    public async Task Run_Should_Return_BadRequest_When_Request_Body_Empty()
    {
        // Act
        var result = await _function.RunAsync(_request.Object);

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        _callFunction.Verify(call => call.SendPost(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
    }

    [TestMethod]
    public async Task Run_Should_Return_BadRequest_When_Request_Body_Invalid()
    {
        // Arrange
        SetUpRequestBody("Invalid request body");

        // Act
        var result = await _function.RunAsync(_request.Object);

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        _callFunction.Verify(call => call.SendPost(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
    }

    #region NhsNumber Rule Tests
    [TestMethod]
    [DataRow("0000000000")]
    [DataRow("9999999999")]
    public async Task Run_Should_Not_Create_Exceptions_When_NhsNumber_Rule_Passes(string nhsNumber)
    {
        // Arrange
        _participantCsvRecord.Participant.NhsNumber = nhsNumber;
        var json = JsonSerializer.Serialize(_participantCsvRecord);
        SetUpRequestBody(json);

        // Act
        await _function.RunAsync(_request.Object);

        // Assert
        _callFunction.Verify(call => call.SendPost(It.Is<string>(s => s == "CreateValidationExceptionURL"), It.Is<string>(s => s.Contains(""""RuleName":"NhsNumber""""))), Times.Never());
    }

    [TestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("0")]
    [DataRow("999999999")]      // 9 digits
    [DataRow("12.3456789")]     // 9 digits and 1 non-digit
    [DataRow("12.34567899")]    // 10 digits and 1 non-digit
    [DataRow("10000000000")]    // 11 digits
    public async Task Run_Should_Return_BadRequest_And_Create_Exception_When_NhsNumber_Rule_Fails(string nhsNumber)
    {
        // Arrange
        _participantCsvRecord.Participant.NhsNumber = nhsNumber;
        var json = JsonSerializer.Serialize(_participantCsvRecord);
        SetUpRequestBody(json);

        // Act
        var result = await _function.RunAsync(_request.Object);

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        _callFunction.Verify(call => call.SendPost(It.Is<string>(s => s == "CreateValidationExceptionURL"),It.Is<string>(s => s.Contains(""""RuleName":"NhsNumber""""))), Times.Once());
    }
    #endregion

    #region SupersededByNhsNumber Rule Tests
    [TestMethod]
    [DataRow(null)]
    [DataRow("0000000000")]
    [DataRow("9999999999")]
    public async Task Run_Should_Not_Create_Exceptions_When_SupersededByNhsNumber_Rule_Passes(string supersededByNhsNumber)
    {
        // Arrange
        _participantCsvRecord.Participant.SupersededByNhsNumber = supersededByNhsNumber;
        var json = JsonSerializer.Serialize(_participantCsvRecord);
        SetUpRequestBody(json);

        // Act
        await _function.RunAsync(_request.Object);

        // Assert
        _callFunction.Verify(call => call.SendPost(It.Is<string>(s => s == "CreateValidationExceptionURL"), It.Is<string>(s => s.Contains(""""RuleName":"SupersededByNhsNumber""""))), Times.Never());
    }

    [TestMethod]
    [DataRow("")]
    [DataRow("0")]
    [DataRow("999999999")]      // 9 digits
    [DataRow("12.3456789")]     // 9 digits and 1 non-digit
    [DataRow("12.34567899")]    // 10 digits and 1 non-digit
    [DataRow("10000000000")]    // 11 digits
    public async Task Run_Should_Return_BadRequest_And_Create_Exception_When_SupersededByNhsNumber_Rule_Fails(string supersededByNhsNumber)
    {
        // Arrange
        _participantCsvRecord.Participant.SupersededByNhsNumber = supersededByNhsNumber;
        var json = JsonSerializer.Serialize(_participantCsvRecord);
        SetUpRequestBody(json);

        // Act
        var result = await _function.RunAsync(_request.Object);

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        _callFunction.Verify(call => call.SendPost(It.Is<string>(s => s == "CreateValidationExceptionURL"),It.Is<string>(s => s.Contains(""""RuleName":"SupersededByNhsNumber""""))), Times.Once());
    }
    #endregion

    #region RecordType Rule Tests
    [TestMethod]
    [DataRow("New")]
    [DataRow("Amended")]
    [DataRow("Removed")]
    public async Task Run_Should_Not_Create_Exception_When_RecordType_Rule_Passes(string recordType)
    {
        // Arrange
        _participantCsvRecord.Participant.RecordType = recordType;
        var json = JsonSerializer.Serialize(_participantCsvRecord);
        SetUpRequestBody(json);

        // Act
        await _function.RunAsync(_request.Object);

        // Assert
        _callFunction.Verify(call => call.SendPost(It.Is<string>(s => s == "CreateValidationExceptionURL"), It.Is<string>(s => s.Contains(""""RuleName":"RecordType""""))), Times.Never());
    }

    [TestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("Newish")]
    public async Task Run_Should_Return_BadRequest_And_Create_Exception_When_RecordType_Rule_Fails(string recordType)
    {
        // Arrange
        _participantCsvRecord.Participant.RecordType = recordType;
        var json = JsonSerializer.Serialize(_participantCsvRecord);
        SetUpRequestBody(json);

        // Act
        var result = await _function.RunAsync(_request.Object);

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        _callFunction.Verify(call => call.SendPost(It.Is<string>(s => s == "CreateValidationExceptionURL"), It.Is<string>(s => s.Contains(""""RuleName":"RecordType""""))), Times.Once());
    }
    #endregion

    #region CurrentPosting Rule Tests
    [TestMethod]
    [DataRow(null)]
    [DataRow("England")]
    [DataRow("Wales")]
    [DataRow("IoM")]
    public async Task Run_Should_Not_Create_Exception_When_CurrentPosting_Rule_Passes(string currentPosting)
    {
        // Arrange
        _participantCsvRecord.Participant.CurrentPosting = currentPosting;
        var json = JsonSerializer.Serialize(_participantCsvRecord);
        SetUpRequestBody(json);

        // Act
        await _function.RunAsync(_request.Object);

        // Assert
        _callFunction.Verify(call => call.SendPost(It.Is<string>(s => s == "CreateValidationExceptionURL"), It.Is<string>(s => s.Contains(""""RuleName":"CurrentPosting""""))), Times.Never());
    }

    [TestMethod]
    [DataRow("")]
    [DataRow("Scotland")]
    public async Task Run_Should_Return_BadRequest_And_Create_Exception_When_CurrentPosting_Rule_Fails(string currentPosting)
    {
        // Arrange
        _participantCsvRecord.Participant.CurrentPosting = currentPosting;
        var json = JsonSerializer.Serialize(_participantCsvRecord);
        SetUpRequestBody(json);

        // Act
        var result = await _function.RunAsync(_request.Object);

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        _callFunction.Verify(call => call.SendPost(It.Is<string>(s => s == "CreateValidationExceptionURL"), It.Is<string>(s => s.Contains(""""RuleName":"CurrentPosting""""))), Times.Once());
    }
    #endregion

    #region PreviousPosting Rule Tests
    [TestMethod]
    [DataRow(null)]
    [DataRow("England")]
    [DataRow("Wales")]
    [DataRow("IoM")]
    public async Task Run_Should_Not_Create_Exception_When_PreviousPosting_Rule_Passes(string previousPosting)
    {
        // Arrange
        _participantCsvRecord.Participant.PreviousPosting = previousPosting;
        var json = JsonSerializer.Serialize(_participantCsvRecord);
        SetUpRequestBody(json);

        // Act
        await _function.RunAsync(_request.Object);

        // Assert
        _callFunction.Verify(call => call.SendPost(It.Is<string>(s => s == "CreateValidationExceptionURL"), It.Is<string>(s => s.Contains(""""RuleName":"PreviousPosting""""))), Times.Never());
    }

    [TestMethod]
    [DataRow("")]
    [DataRow("Scotland")]
    public async Task Run_Should_Return_BadRequest_And_Create_Exception_When_PreviousPosting_Rule_Fails(string previousPosting)
    {
        // Arrange
        _participantCsvRecord.Participant.PreviousPosting = previousPosting;
        var json = JsonSerializer.Serialize(_participantCsvRecord);
        SetUpRequestBody(json);

        // Act
        var result = await _function.RunAsync(_request.Object);

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        _callFunction.Verify(call => call.SendPost(It.Is<string>(s => s == "CreateValidationExceptionURL"), It.Is<string>(s => s.Contains(""""RuleName":"PreviousPosting""""))), Times.Once());
    }
    #endregion

    #region ReasonForRemoval Rule Tests
    [TestMethod]
    [DataRow(null)]
    [DataRow("AFL")]
    [DataRow("AFN")]
    [DataRow("CGA")]
    [DataRow("DEA")]
    [DataRow("DIS")]
    [DataRow("EMB")]
    [DataRow("LDN")]
    [DataRow("NIT")]
    [DataRow("OPA")]
    [DataRow("ORR")]
    [DataRow("RDI")]
    [DataRow("RDR")]
    [DataRow("RFI")]
    [DataRow("RPR")]
    [DataRow("SCT")]
    [DataRow("SDL")]
    [DataRow("SDN")]
    [DataRow("TRA")]
    public async Task Run_Should_Not_Create_Exception_When_ReasonForRemoval_Rule_Passes(string reasonForRemoval)
    {
        // Arrange
        _participantCsvRecord.Participant.ReasonForRemoval = reasonForRemoval;
        var json = JsonSerializer.Serialize(_participantCsvRecord);
        SetUpRequestBody(json);

        // Act
        await _function.RunAsync(_request.Object);

        // Assert
        _callFunction.Verify(call => call.SendPost(It.Is<string>(s => s == "CreateValidationExceptionURL"), It.Is<string>(s => s.Contains(""""RuleName":"ReasonForRemoval""""))), Times.Never());
    }

    [TestMethod]
    [DataRow("")]
    [DataRow("ABC")]
    [DataRow("123")]
    public async Task Run_Should_Return_BadRequest_And_Create_Exception_When_ReasonForRemoval_Rule_Fails(string reasonForRemoval)
    {
        // Arrange
        _participantCsvRecord.Participant.ReasonForRemoval = reasonForRemoval;
        var json = JsonSerializer.Serialize(_participantCsvRecord);
        SetUpRequestBody(json);

        // Act
        var result = await _function.RunAsync(_request.Object);

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        _callFunction.Verify(call => call.SendPost(It.Is<string>(s => s == "CreateValidationExceptionURL"), It.Is<string>(s => s.Contains(""""RuleName":"ReasonForRemoval""""))), Times.Once());
    }
    #endregion

    private void SetUpRequestBody(string json)
    {
        var byteArray = Encoding.ASCII.GetBytes(json);
        var bodyStream = new MemoryStream(byteArray);

        _request.Setup(r => r.Body).Returns(bodyStream);
    }
}
