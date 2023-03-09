﻿using MediatR;

namespace CQRSMediatR.MediatR.Employee.Query
{
    public class GetSingleEmployeeQuery : IRequest<Entities.Employee>
    {
        public long Id { get; }

        public GetSingleEmployeeQuery(long id)
        => Id = id;
    }
}
