import AdminLayout from "@/layouts/Admin/AdminLayout";
import {
    Dashboard,
    Artists,
    ArtistCreateForm,
    ArtistDetailsForm,
    ArtistUpdateForm,
    Albums,
    Songs,
    Events,
    EventsCreateForm,
    Tickets,
    MusicalProjects,
    Users,
    Roles,
    Error404,
    Error500,
    UsersDetailsForm,
} from '@/pages/Admin'


const adminRoutes = [
    {
        path: "/admin",
        element: <AdminLayout />,
        errorElement: <Error404 />,
        children: [
            { path: "", element: <Dashboard />, label: "Dashboard" },
            { path: "artists", element: <Artists />, label: "Artists" },
            { path: "artists/create", element: <ArtistCreateForm />, label: "ArtistsCreate" },
            { path: "artists/:artistId", element: <ArtistDetailsForm />, label: "ArtistsDetails" },
            { path: "artists/:artistId/edit", element: <ArtistUpdateForm />, label: "ArtistsUpdate" },
            { path: "albums", element: <Albums />, label: "Albums" },
            { path: "songs", element: <Songs />, label: "Songs" },
            { path: "events", element: <Events />, label: "Events" },
            { path: "events/create", element: <EventsCreateForm />, label: "EventsCreate" },
            { path: "tickets", element: <Tickets />, label: "Tickets"},
            { path: "musicalProjects", element: <MusicalProjects />, label: "MusicalProjects" },
            { path: "users", element: <Users />, label: "Users" },
            { path: "users/:userId", element: <UsersDetailsForm />, label: "UsersDetails" },
            { path: "roles", element: <Roles />, label: "Roles" }
        ]
    },
    { path: "error500", element: <Error500 /> }
];

export default adminRoutes;

