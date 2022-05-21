using System.Windows.Forms;

namespace AsteroidsGame_HomeWork_
{
    public sealed class Creater
    {
        internal Ship ship;

        internal CometsList comet;
        internal BulletsList bulletsList;
        internal HealthList healthList;
        internal AsteroidsList asteroidsList;
        internal StarsList starsList;

        private InputController inputController;
        private SoundController soundController;
        private GameController gameController;
        private PointsController pointsController;

        private IFactories objectFactories;


        public Creater(Form form, Timer timer)
        {
            CreateAllObjects(form, timer);
        }

        private void CreateAllObjects(Form form, Timer timer)
        {
            objectFactories = new Factories();
           
            ship = (Ship)objectFactories.FactoryShip().CreateShip();

            asteroidsList = new AsteroidsList(objectFactories.FactoryAsteroids(), ship, ship);
            bulletsList = new BulletsList(asteroidsList, objectFactories.FactoryBullets());
            starsList = new StarsList(objectFactories.FactoryStars());
            comet = new CometsList(objectFactories.FactoryComet());
            healthList = new HealthList(objectFactories.FactoryHealth(),ship, ship);

            soundController = new SoundController();
            inputController = new InputController(form, ship);
            pointsController = new PointsController();
            gameController = new GameController(asteroidsList, ship, timer, pointsController);
            
            ship.LoadDataObject(bulletsList, soundController, pointsController);
            asteroidsList.LoadDataObject(soundController);
            healthList.LoadDataObject(soundController);
        }
    }
}
