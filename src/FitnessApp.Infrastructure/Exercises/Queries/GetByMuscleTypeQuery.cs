namespace FitnessApp.Infrastructure.Exercises.Queries;

using FitnessApp.Core.Exercises.Models;
using MediatR;

public class GetByMuscleTypeQuery : IRequest<IEnumerable<Exercise>?>
{
    public MuscleType? MuscleType { get; set; }

    public GetByMuscleTypeQuery(MuscleType muscleType)
    {
        this.MuscleType = muscleType;
    }

    public GetByMuscleTypeQuery() { }
}