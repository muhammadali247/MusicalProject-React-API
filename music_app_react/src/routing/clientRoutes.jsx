import ClientLayout from "@/layouts/Client/ClientLayout";
import Home from '@/pages/Client/Home/Home'
import About from '@/pages/Client/About/About'
import Events from '@/pages/Client/Events/Events'
import Contact from '@/pages/Client/Contact/Contact'
import Discover from '@/pages/Client/Discover/Discover'
import Account from "@/pages/Client/Account/Account";
import Error404 from "@/pages/Admin/Errors/Error404/Error404";
import HomeIcon from '@mui/icons-material/Home';
import AboutIcon from '@mui/icons-material/Info';
import EventsIcon from '@mui/icons-material/Event';
import ContactIcon from '@mui/icons-material/ContactMail';
import DiscoverIcon from '@mui/icons-material/LibraryMusic';
import ManageAccountsIcon from "@mui/icons-material/ManageAccounts";

const ClientRoutes = [
    {
        path: "/",
        element: <ClientLayout />,
        errorElement: <Error404 />,
        children: [
            { path: "", element: <Home />, label: 'Home', icon: <HomeIcon /> },
            { path: "about", element: <About />, label: 'About', icon: <AboutIcon /> },
            { path: "events", element: <Events />, label: 'Events', icon: <EventsIcon /> },
            { path: "discover", element: <Discover />, label: 'Discover', icon: <DiscoverIcon /> },
            { path: "contact", element: <Contact />, label: 'Contact', icon: <ContactIcon /> },
            { path: "Account", element: <Account />, label: 'Account', icon: <ManageAccountsIcon /> },
        ]
    }
];

export default ClientRoutes;

