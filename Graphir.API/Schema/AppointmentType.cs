﻿using Graphir.API.Practitioners;
using Hl7.Fhir.Model;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Graphir.API.Patients;

namespace Graphir.API.Schema;

public class AppointmentType : ObjectType<Appointment>
{
    protected override void Configure(IObjectTypeDescriptor<Appointment> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.Meta).Type<MetaType>();
        descriptor.Field(x => x.Identifier).Type<ListType<IdentifierType>>();
        descriptor.Field(x => x.Status).Type<EnumType<Appointment.AppointmentStatus>>();
        descriptor.Field(x => x.ServiceType).Type<ListType<CodeableConceptType>>();

        descriptor.Field(x => x.Start).Type<DateTimeType>();
        descriptor.Field(x => x.End).Type<DateTimeType>();
        
        descriptor.Field(x => x.Created).Type<StringType>();
        descriptor.Field(x => x.Comment).Type<StringType>();
        descriptor.Field(x => x.Description).Type<StringType>();
        descriptor.Field(x => x.Priority).Type<IntType>();
        descriptor.Field(x => x.MinutesDuration).Type<IntType>();
        descriptor.Field(x => x.AppointmentType).Type<CodeableConceptType>();
        descriptor.Field(x => x.ReasonCode).Type<ListType<CodeableConceptType>>();

        descriptor.Field(x => x.CommentElement).Type<FhirStringType>();
        descriptor.Field(x => x.ServiceCategory).Type<ListType<CodeableConceptType>>();
      
        descriptor.Field(x => x.Participant).Type<ListType<AppointmentParticipantType>>();
    }
 
}


// type AppointmentParticipant {
public class AppointmentParticipantType : ObjectType<Appointment.ParticipantComponent>
{

    protected override void Configure(IObjectTypeDescriptor<Appointment.ParticipantComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Type).Type<CodeableConceptType>();
        descriptor.Field(x => x.Period).Type<PeriodType>();
        descriptor.Field(x => x.Required).Type<BooleanType>();
        descriptor.Field(x => x.Status).Type<StringType>().ResolveWith<AppointmentResolvers>(t => t.GetStatus(default!, default));

        descriptor.Field(x => x.Actor).Type<ResourceReferenceType<ActorReferenceType>>();

        // WIP, commenting out for now to preserve compilation
        // actor: Reference
        // status: code  _status: ElementBase
    }

    private class AppointmentResolvers
    {
        public async Task<object?> GetActorReferenceAsync(
            [Parent] Appointment.ParticipantComponent participant,
            //ResourceReferenceByIdDataLoader loader,
            PatientByIdDataLoader loader,
            CancellationToken cancellationToken)
        {
            if (participant.Actor.Reference is null)
            {
                // return 'psuedo-reference' type
            }
            else
            {
                var patId = participant.Actor.Reference.Split('/').LastOrDefault();
                var results = await loader.LoadAsync(patId, cancellationToken);
                //var results = await loader.LoadAsync(participant.Actor.Reference, cancellationToken);
                return results;
            }
            return null;
        }

        public string GetStatus(
            [Parent] Appointment.ParticipantComponent participant,
            CancellationToken cancellationToken)
        {
            return participant.Status.Value.ToString();
        }
    }
    
}


public class ActorReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ActorReference");
        descriptor.Type<PatientType>();
        descriptor.Type<PractitionerType>();
        //descriptor.Type<PractitionerRoleType>();
        //descriptor.Type<RelatedPersonType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<HealthcareServiceType>();
        descriptor.Type<LocationType>();
    }
}
