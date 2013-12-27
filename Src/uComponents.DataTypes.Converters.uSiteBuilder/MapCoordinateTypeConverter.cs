using System;
using uComponents.DataTypes.Converters.uSiteBuilder.Types;
using Vega.USiteBuilder.Types;

namespace uComponents.DataTypes.Converters.uSiteBuilder
{
    public class MapCoordinateTypeConverter : ICustomTypeConvertor
    {
        public Type ConvertType
        {
            get { return typeof (MapCoordinate); }
        }

        public object ConvertValueWhenRead(object inputValue)
        {
            var coordStr = inputValue as string;
            var mapCoordinate = new MapCoordinate {Latitude = 0, Longitude = 0, Zoom = 12};
            if (coordStr != null)
            {
                var vals = coordStr.Split(new[] {','});
                if (vals.Length == 3)
                {
                    mapCoordinate = new MapCoordinate
                    {
                        Latitude = float.Parse(vals[0]),
                        Longitude = float.Parse(vals[1]),
                        Zoom = int.Parse(vals[2])
                    };
                }
            }
            return mapCoordinate;
        }

        public object ConvertValueWhenWrite(object inputValue)
        {
            var coord = inputValue as MapCoordinate;
            return coord == null 
                ? "0,0,12" 
                : string.Format("{0},{1},{2}", coord.Latitude, coord.Longitude, coord.Zoom);
        }
    }
}
