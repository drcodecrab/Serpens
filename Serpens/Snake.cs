using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serpens
{
    class Snake
    {
        public List<Point> points;
        public Point kopf;
        public Boolean isAlive;
        public Boolean isEating;
        public Snake(int _x, int _y, int _startSize)
        {
            kopf = new Point(_x, _y);
            points = new List<Point>();
            CreateNew(_startSize);
            isAlive = true;
            isEating = false;
        }

        public void CreateNew(int startSize)
        {
            for (int i = 0; i < startSize; i++)
            {
                points.Add(new Point(kopf.x + i, kopf.y));
            }
        }

        public void DeleteEndOfBody()
        {
            if (points.Count != 0)
            {
                points.RemoveAt(0);
            }
        }

        public void AddElementToSnake(Point _newHead)
        {
            points.Add(_newHead);
        }
        public void CheckOwnCollision()
        {

            for (int i = 0; i < points.Count - 1; i++)
            {
                if (points[points.Count - 1].x == points[i].x && points[points.Count - 1].y == points[i].y)
                {
                    isAlive = false;
                }
            }
        }

        public void Update()
        {
            AddElementToSnake(GetNewHeadPosition());

            if (!isEating)
            {
                DeleteEndOfBody();
            }
            CheckOwnCollision();
        }
        public Point GetNewHeadPosition()
        {
            Point currentFrontPoint = new Point(0, 0);

            if (points.Count != 0)
            {
                currentFrontPoint = points[points.Count - 1];
            }
            
            if (GlobalVars.aktuelleRichtung == Bewegungsrichtung.rechts)
            {
                currentFrontPoint = new Point(currentFrontPoint.x + 1, currentFrontPoint.y);
            }
            if (GlobalVars.aktuelleRichtung == Bewegungsrichtung.links)
            {
                currentFrontPoint = new Point(currentFrontPoint.x - 1, currentFrontPoint.y);
            }
            if (GlobalVars.aktuelleRichtung == Bewegungsrichtung.oben)
            {
                currentFrontPoint = new Point(currentFrontPoint.x, currentFrontPoint.y - 1);
            }
            if (GlobalVars.aktuelleRichtung == Bewegungsrichtung.unten)
            {
                currentFrontPoint = new Point(currentFrontPoint.x, currentFrontPoint.y + 1);
            }

            return currentFrontPoint;
        }


    }
}
