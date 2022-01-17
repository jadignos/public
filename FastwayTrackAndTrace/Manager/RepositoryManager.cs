using FastwayApiManager.Model;
using System.Collections.Generic;
using System.Linq;

namespace FastwayApiManager.Manager
{
    public class RepositoryManager
    {
        private List<TrackingLabelDto> labels;

        public RepositoryManager() => labels = new List<TrackingLabelDto>();

        public void Add(TrackingLabelDto trackingLabel) => labels.Add(trackingLabel);

        public void AddRange(List<TrackingLabelDto> trackingLabels) => labels.AddRange(trackingLabels);

        public List<TrackingLabelDto> GetAll() => labels.ToList();

        public void Clear() => labels.Clear();
    }
}
