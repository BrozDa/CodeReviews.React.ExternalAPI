import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from '../pages/Home';
import CarPage from '../pages/CarPage';

const AppRoutes = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/cars/:id" element={<CarPage />} />
      </Routes>
    </Router>
  );
};

export default AppRoutes;