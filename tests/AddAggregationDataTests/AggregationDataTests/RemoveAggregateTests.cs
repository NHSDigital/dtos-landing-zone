namespace NHS.CohortManager.Tests.AddAggregationDataTests;

using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using Common;
using Data.Database;
using Microsoft.Extensions.Logging;
using Model;
using Model.Enums;
using Moq;

[TestClass]
public class RemoveAggregationTests
{

    private readonly Mock<IDbConnection> _mockDBConnection = new();
    private readonly Mock<IDbCommand> _commandMock = new();
    private readonly Mock<IDataReader> _mockDataReader = new();
    private readonly Mock<ILogger<CreateAggregationData>> _loggerMock = new();
    private readonly Mock<IDatabaseHelper> _databaseHelperMock = new();
    private readonly Mock<IDbDataParameter> _mockParameter = new();
    private readonly Mock<IDbTransaction> _mockTransaction = new();

    public RemoveAggregationTests()
    {
        Environment.SetEnvironmentVariable("DtOsDatabaseConnectionString", "DtOsDatabaseConnectionString");
        Environment.SetEnvironmentVariable("LookupValidationURL", "LookupValidationURL");

        _mockDBConnection.Setup(x => x.ConnectionString).Returns("someFakeCOnnectionString");
        _mockDBConnection.Setup(x => x.BeginTransaction()).Returns(_mockTransaction.Object);

        _commandMock.Setup(c => c.Dispose());
        _commandMock.SetupSequence(m => m.Parameters.Add(It.IsAny<IDbDataParameter>()));
        _commandMock.Setup(m => m.Parameters.Clear()).Verifiable();
        _commandMock.SetupProperty<System.Data.CommandType>(c => c.CommandType);
        _commandMock.SetupProperty<string>(c => c.CommandText);
        _commandMock.Setup(x => x.CreateParameter()).Returns(_mockParameter.Object);

        _mockDBConnection.Setup(m => m.CreateCommand()).Returns(_commandMock.Object);
        _commandMock.Setup(m => m.Parameters.Add(It.IsAny<IDbDataParameter>())).Verifiable();
        _commandMock.Setup(m => m.ExecuteReader())
        .Returns(_mockDataReader.Object);
        _mockDBConnection.Setup(conn => conn.Open());

        _databaseHelperMock.Setup(helper => helper.ConvertNullToDbNull(It.IsAny<string>())).Returns(DBNull.Value);
        _databaseHelperMock.Setup(helper => helper.ParseDates(It.IsAny<string>())).Returns(DateTime.Today);
    }

    [TestMethod]
    public void UpdateAggregateParticipantAsInactive_Success()
    {
        //Arrange
        var updateAggregateData = new CreateAggregationData(
            _mockDBConnection.Object,
            _databaseHelperMock.Object,
            _loggerMock.Object
        );
        _commandMock.Setup(x => x.ExecuteNonQuery()).Returns(1);
        var NHSID = "123456";

        //Act
        var result = updateAggregateData.UpdateAggregateParticipantAsInactive(NHSID);


        //Assert
        Assert.IsTrue(result);
        _commandMock.Verify(m => m.ExecuteNonQuery(), Times.Once);
    }

    [TestMethod]
    public void UpdateAggregateParticipantAsInactive_ParticipantNotExists_Failure()
    {
        //Arrange
        var updateAggregateData = new CreateAggregationData(
            _mockDBConnection.Object,
            _databaseHelperMock.Object,
            _loggerMock.Object
        );
        _commandMock.Setup(x => x.ExecuteNonQuery()).Returns(0);
        var NHSID = "654321";
        //Act
        var result = updateAggregateData.UpdateAggregateParticipantAsInactive(NHSID);


        //Assert
        Assert.IsFalse(result);
        _commandMock.Verify(m => m.ExecuteNonQuery(), Times.Once);
    }

    [TestMethod]
    public void UpdateAggregateParticipantAsInactive_NoNHSIDProvided_Failure()
    {
        //Arrange
        var updateAggregateData = new CreateAggregationData(
            _mockDBConnection.Object,
            _databaseHelperMock.Object,
            _loggerMock.Object
        );
        _commandMock.Setup(x => x.ExecuteNonQuery()).Returns(0);
        var NHSID = "";
        //Act
        var result = updateAggregateData.UpdateAggregateParticipantAsInactive(NHSID);


        //Assert
        Assert.IsFalse(result);
        _commandMock.Verify(m => m.ExecuteNonQuery(), Times.Never);
    }

}
