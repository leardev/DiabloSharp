using System;
using System.Collections.Generic;
using DiabloSharp.Features;

namespace DiabloSharp.Models
{
    public abstract class ModelFeatureBase<T> : ModelBase<T>
    {
        private readonly Dictionary<Type, IItemFeature> _features;

        protected ModelFeatureBase()
        {
            _features = new Dictionary<Type, IItemFeature>();
        }

        public bool TryGetFeature<TFeature>(out TFeature value) where TFeature : IItemFeature
        {
            var featureType = typeof(TFeature);
            if (_features.TryGetValue(featureType, out var feature))
            {
                value = (TFeature)feature;
                return true;
            }

            value = default;
            return false;
        }

        public void AddFeature<TFeature>(TFeature feature) where TFeature : IItemFeature
        {
            var featureType = typeof(TFeature);
            _features.Add(featureType, feature);
        }
    }
}