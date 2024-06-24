using Model;
using Model.Enums;

namespace Common;

public class CreateParticipant : ICreateParticipant
{
    public Participant CreateResponseParticipantModel(BasicParticipantData participant, Demographic demographic)
    {
        return new Participant
        {
            RecordType = participant.RecordType,
            ChangeTimeStamp = participant.ChangeTimeStamp,
            SerialChangeNumber = participant.SerialChangeNumber,
            NHSId = participant.NHSId,
            SupersededByNhsNumber = participant.SupersededByNhsNumber,
            PrimaryCareProvider = demographic.PrimaryCareProvider,
            PrimaryCareProviderEffectiveFromDate = participant.PrimaryCareProviderEffectiveFrom,
            CurrentPosting = demographic.CurrentPosting,
            CurrentPostingEffectiveFromDate = participant.CurrentPostingEffectiveFrom,
            PreviousPosting = participant.PreviousPosting,
            PreviousPostingEffectiveFromDate = participant.PreviousPostingEffectiveFrom,
            NamePrefix = demographic.NamePrefix,
            FirstName = demographic.GivenName,
            OtherGivenNames = participant.OtherGivenNames,
            Surname = demographic.FamilyName,
            PreviousSurname = participant.PreviousSurname,
            DateOfBirth = demographic.DateOfBirth,
            Gender = (Gender)Enum.Parse(typeof(Gender), demographic.Gender, true),
            AddressLine1 = demographic.AddressLine1,
            AddressLine2 = demographic.AddressLine2,
            AddressLine3 = demographic.AddressLine3,
            AddressLine4 = demographic.AddressLine4,
            AddressLine5 = participant.AddressLine5,
            Postcode = demographic.PostCode,
            PafKey = participant.PafKey,
            UsualAddressEffectiveFromDate = participant.UsualAddressEffectiveFromDate,
            ReasonForRemoval = participant.RemovalReason,
            ReasonForRemovalEffectiveFromDate = participant.RemovalEffectiveFromDate,
            DateOfDeath = demographic.DateOfDeath,
            DeathStatus = demographic.DateOfDeath != null ? Status.Formal : Status.Informal,
            TelephoneNumber = demographic.TelephoneNumberHome,
            TelephoneNumberEffectiveFromDate = participant.TelephoneNumberEffectiveFromDate,
            MobileNumber = participant.MobileNumber,
            MobileNumberEffectiveFromDate = participant.MobileNumberEffectiveFromDate,
            EmailAddress = demographic.EmailAddressHome,
            EmailAddressEffectiveFromDate = participant.EmailAddressEffectiveFromDate,
            PreferredLanguage = demographic.PreferredLanguage,
            IsInterpreterRequired = demographic.InterpreterRequired,
            InvalidFlag = participant.InvalidFlag,
            ChangeReasonCode = participant.ChangeReasonCode
        };
    }
}
