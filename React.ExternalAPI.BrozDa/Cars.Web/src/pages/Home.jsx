import { useEffect, useState } from "react";
import CarCard from "../components/CarCard"
import "../css/Home.css"
import { getCars } from '../services/api';
import Loading from "../components/Loading";
import Error from "../components/Error";

function Home() {

  const [carList,setCarList] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(()=>{
    const loadCars = async () => {
      try{
        const cars = await getCars();
        setCarList(cars);
      } catch (err) {
        console.log(err);
        setError("Failed to load cars...");
      } finally {
        setLoading(false);
      }
    };
    loadCars();
    },[]);
    
    if (error) return <Error errorMsg={error}/>;
    if (loading) return <Loading/>;

  return (
    <>
    <div className="cars-grid">
      {carList.map(c => <CarCard key={c.id} carId={c.id} carName={c.name} imgUrl={c.imageUrl}/>)}
    </div>
    
    </>
  )
}

export default Home