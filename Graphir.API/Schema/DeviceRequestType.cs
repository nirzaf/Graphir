using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class DeviceRequestType : ObjectType<DeviceRequest>
{
    // TODO: finish DeviceRequest
    
    /*
type DeviceRequest {
  id: ID
  meta: Meta
  implicitRules: uri  _implicitRules: ElementBase
  language: code  _language: ElementBase
  text: Narrative
  contained: [Resource]
  extension: [Extension]
  modifierExtension: [Extension]
  identifier: [Identifier]
  instantiatesCanonical: canonical  _instantiatesCanonical: [ElementBase]
  instantiatesUri: uri  _instantiatesUri: [ElementBase]
  basedOn: [Reference]
  priorRequest: [Reference]
  groupIdentifier: Identifier
  status: code  _status: ElementBase
  intent: code  _intent: ElementBase
  priority: code  _priority: ElementBase
  doNotPerform: Boolean  _doNotPerform: ElementBase
  code: CodeableReference!
  quantity: Int  _quantity: ElementBase
  parameter: [DeviceRequestParameter]
  subject: Reference!
  encounter: Reference
  occurrenceDateTime: dateTime  _occurrenceDateTime: ElementBase
  occurrencePeriod: Period
  occurrenceTiming: Timing
  authoredOn: dateTime  _authoredOn: ElementBase
  requester: Reference
  performerType: CodeableConcept
  performer: Reference
  reason: [CodeableReference]
  insurance: [Reference]
  supportingInfo: [Reference]
  note: [Annotation]
  relevantHistory: [Reference]
}
     */
    
    protected override void Configure(IObjectTypeDescriptor<DeviceRequest> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.ImplicitRules);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Contained);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.InstantiatesCanonical);
        descriptor.Field(x => x.InstantiatesUri);
        descriptor.Field(x => x.BasedOn);
        descriptor.Field(x => x.PriorRequest);
        descriptor.Field(x => x.GroupIdentifier);
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Intent);
        descriptor.Field(x => x.Priority);
        descriptor.Field(x => x.Parameter);
        descriptor.Field(x => x.Subject);
        descriptor.Field(x => x.Encounter);
        descriptor.Field(x => x.AuthoredOn);
        descriptor.Field(x => x.Requester);
        descriptor.Field(x => x.PerformerType);
        descriptor.Field(x => x.Performer);
        descriptor.Field(x => x.ReasonCode);
        descriptor.Field(x => x.Insurance);
        descriptor.Field(x => x.SupportingInfo);
        descriptor.Field(x => x.Note);
        descriptor.Field(x => x.RelevantHistory);
    }
}
