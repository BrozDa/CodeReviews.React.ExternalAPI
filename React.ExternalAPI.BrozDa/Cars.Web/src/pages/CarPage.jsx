import { useParams } from 'react-router-dom'
import { getCarByID } from '../services/api';
import { useEffect, useState } from 'react';
import CarDetail from '../components/CarDetail';
import Loading from '../components/Loading';

function CarPage() {

  const [carDetail, setCarDetail] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const {id} = useParams();

  useEffect(()=>{
      const loadCarDetails = async () => {
        try{
          const car = await getCarByID(id);
          setCarDetail(car);
        } catch (err) {
          console.log(err);
          setError("Failed to load car details...");
        } finally {
          setLoading(false);
        }
      };
      loadCarDetails();
      },[]);

  if (error) return <p>{error}</p>;
  if (loading) return <Loading/>;

return (
  <CarDetail 
    key={carDetail.id}
    carId={carDetail.id}
    carName={carDetail.name}
    carImg={carDetail.imageUrl}
    carDescription={carDetail.description}
  />
);
}

export default CarPage