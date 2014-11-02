using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class PointsRepository
    {
        /// <summary>
        /// Insert new point in the database.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public int InsertPoints(Point point)
        {
            point.AddedDate = DateTime.Now.Date;
            using (var conn = new Saloon4KEntities())
            {
                conn.AddToPoints(point);
                conn.SaveChanges();
            }
            return point.PointsId;
        }

        /// <summary>
        /// Update points in the database.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public int UpdatePoints(Point point)
        {
            using (var conn = new Saloon4KEntities())
            {
                var p = conn.Points.FirstOrDefault(x => x.PointsId == point.PointsId);
                if (p != null)
                {
                    p.AddedDate = DateTime.Now.Date;
                    p.PointsFor = point.PointsFor;
                    p.PointsCount = point.PointsCount;
                    p.PointsId = point.PointsId;
                    conn.SaveChanges();
                }
            }
            return point.PointsId;
        }

        /// <summary>
        /// Get a point entity based on the id.
        /// </summary>
        /// <param name="pointId"></param>
        /// <returns></returns>
        public Point GetPointById(int pointId)
        {
            Point p;
            using (var conn = new Saloon4KEntities())
            {
                p = conn.Points.FirstOrDefault(x => x.PointsId == pointId);
            }
            return p;
        }

        /// <summary>
        /// Get all points.
        /// </summary>
        /// <returns></returns>
        public List<Point> GetAllPoints()
        {
            List<Point> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.Points.OrderByDescending(x => x.PointsId).ToList();
            }
            return list;
        }

        /// <summary>
        /// Delete a point entity from the data base.
        /// </summary>
        /// <param name="pointId"></param>
        public void DeletePoint(int pointId)
        {
            using (var conn = new Saloon4KEntities())
            {
                var point = conn.Points.FirstOrDefault(x => x.PointsId == pointId);
                conn.Points.DeleteObject(point);
                conn.SaveChanges();
            }
        }
    }
}
