using MediatR;

namespace CQRSMediatR.MediatR.Employee.Query
{
    public class GetAllEmployeeQuery:IRequest<List<Entities.Employee>>
    {

    }
}
