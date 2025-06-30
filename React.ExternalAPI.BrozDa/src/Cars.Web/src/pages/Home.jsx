import { useEffect, useState } from "react";
import CarCard from "../components/CarCard"
import "../css/Home.css"
import { getCars } from '../services/api';


function Home() {

  const [carList,setCarList] = useState([]);
  const [loading, setLoading] = useState(true);


  useEffect(()=>{
    const loadCars = async () => {
      try{
        const cars = await getCars();
        setCarList(cars);
      } catch (err) {
        console.log(err);
        setError("Failed to load movies...");
      } finally {
        setLoading(false);
      }
    };
    loadCars();
    },[]);
  return (
    <>
    <div className="cars-grid">
      {carList.map(c => <CarCard key={c.id} carName={c.name} imgUrl={c.imageUrl}/>)}
    </div>
    
    </>
  )
}

export default Home