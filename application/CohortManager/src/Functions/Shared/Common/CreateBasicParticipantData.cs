using Model;

namespace Common;

public class CreateBasicParticipantData : ICreateBasicParticipantData
{
    public BasicParticipantData BasicParticipantData(Participant participant)
    {
        return new BasicParticipantData
        {
            RecordType = participant.RecordType,
            ChangeTimeStamp = participant.ChangeTimeStamp,
            SerialChangeNumber = participant.SerialChangeNumber,
            NHSId = participant.NHSId,
            SupersededByNhsNumber = participant.SupersededByNhsNumber,
            PrimaryCareProviderEffectiveFrom = participant.PrimaryCareProviderEffectiveFrom,
            CurrentPostingEffectiveFrom = participant.CurrentPostingEffectiveFrom,
            PreviousPosting = participant.PreviousPosting,
            PreviousPostingEffectiveFrom = participant.PreviousPostingEffectiveFrom,
            OtherGivenNames = participant.OtherGivenNames,
            PreviousSurname = participant.PreviousSurname,
            AddressLine5 = participant.AddressLine5,
            PafKey = participant.PafKey,
            UsualAddressEffectiveFromDate = participant.UsualAddressEffectiveFromDate,
            TelephoneNumberEffectiveFromDate = participant.TelephoneNumberEffectiveFromDate,
            MobileNumber = participant.MobileNumber,
            MobileNumberEffectiveFromDate = participant.MobileNumberEffectiveFromDate,
            EmailAddressEffectiveFromDate = participant.EmailAddressEffectiveFromDate,
            InvalidFlag = participant.InvalidFlag,
            ChangeReasonCode = participant.ChangeReasonCode
        };
    }
}
