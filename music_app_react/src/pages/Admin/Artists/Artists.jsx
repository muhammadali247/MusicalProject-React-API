import { Box, Typography, useTheme } from "@mui/material";
import { DataGrid, GridToolbar } from "@mui/x-data-grid";
import { tokens } from "@/layouts/Admin/AdminTheme";
import Header from "@/components/Admin/Header/Header";
import { useState, useEffect } from "react";
import axiosInstance from "@/utils/axiosInstance";
import React from "react";
import { useNavigate } from "react-router-dom";
import adminRoutes from "@/routing/adminRoutes";
import { findPathByLabel } from "@/utils/routingUtils";
import IconButton from "@mui/material/IconButton";
import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";
import ViewIcon from "@mui/icons-material/Visibility";
import Button from "@mui/material/Button";
import { darken } from "@mui/system";
import styles from "./Artists.module.scss";
import Tooltip from "@/components/Global/UI/Tooltip";
import { ARTIST_GETALL_URL, ARTIST_DELETE_URL } from "@/constants/Urls";
import DeleteModal from "@/components/Admin/Modals/DeleteModal/DeleteModal";
import { useSnackbar } from "notistack";
import LinearProgress from "@mui/material/LinearProgress";

function Artists() {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  const navigate = useNavigate();
  const [deleteModalOpen, setDeleteModalOpen] = useState(false);
  const [artistIdToDelete, setArtistIdToDelete] = useState(null);
  const { enqueueSnackbar } = useSnackbar();

  const handleAddArtist = () => {
    navigate(findPathByLabel(adminRoutes, "ArtistsCreate"));
  };

  const viewAction = (id) => {
    console.log("View action triggered for ID:", id);
    navigate(findPathByLabel(adminRoutes, "ArtistsDetails", { artistId: id }));
  };

  const editAction = (id) => {
    console.log("Edit action triggered for ID:", id);
    navigate(findPathByLabel(adminRoutes, "ArtistsUpdate", { artistId: id }));
  };

  const deleteAction = (id) => {
    setArtistIdToDelete(id);
    setDeleteModalOpen(true);
  };

  const handleCloseDeleteModal = () => {
    setDeleteModalOpen(false);
    setArtistIdToDelete(null); // Clear the selected artistIdToDelete
  };

  const handleDeleteArtist = () => {
    if (!artistIdToDelete) return; // Ensuring there's an artist ID

    axiosInstance
      .delete(ARTIST_DELETE_URL(artistIdToDelete))
      .then((response) => {
        // Successful deletion: Remove the artist from the 'data' state
        setData((prevData) =>
          prevData.filter((artist) => artist.id !== artistIdToDelete)
        );

        // Close the delete modal
        handleCloseDeleteModal();

        // Show a success notification to the user
        enqueueSnackbar("Artist deleted successfully!", {
          variant: "success",
          autoHideDuration: 5000,
        });
      })
      .catch((error) => {
        console.error("Error deleting the artist: ", error);

        // Check if the error has a response from the server
        if (error.response) {
          if (error.response.status === 500) {
            // Internal server error: Navigate to the error500 page
            navigate("/error500");
          } else if (error.response.data && error.response.data.errors) {
            // Other server-side validation errors: Show them in Snackbars
            const errorsFromServer = error.response.data.errors;
            Object.values(errorsFromServer).forEach((errorArray) => {
              errorArray.forEach((singleError) => {
                enqueueSnackbar(singleError, {
                  variant: "error",
                  autoHideDuration: 5000,
                });
              });
            });
          }
        } else {
          // Other axios errors (e.g., network errors)
          enqueueSnackbar("Failed to delete the artist. Please try again.", {
            variant: "error",
            autoHideDuration: 5000,
          });
        }
      });
  };

  const columns = [
    { field: "id", headerName: "ID", width: 90 },
    { field: "artistName", headerName: "Name", flex: 0.5 },
    {
      field: "projectNames",
      headerName: "Projects",
      flex: 1,
      renderCell: (params) => {
        // Convert the list of projects (which should be an array) to a sorted string
        const sortedProjects = [...params.value].sort(); // Sorting the array
        return sortedProjects.join("; ");
      },
    },
    {
      field: "actions",
      headerName: "Actions",
      headerAlign: "center",
      width: 130,
      renderCell: (params) => (
        <div>
          <Tooltip content="View Artist">
            <IconButton
              onClick={() => viewAction(params.id)}
              color="secondary"
              aria-label="view"
            >
              <ViewIcon />
            </IconButton>
          </Tooltip>
          <Tooltip content="Edit Artist">
            <IconButton
              onClick={() => editAction(params.id)}
              color="secondary"
              aria-label="edit"
            >
              <EditIcon />
            </IconButton>
          </Tooltip>
          <Tooltip content="Delete Artist">
            <IconButton
              onClick={() => deleteAction(params.id)}
              color="secondary"
              aria-label="delete"
            >
              <DeleteIcon />
            </IconButton>
          </Tooltip>
        </div>
      ),
    },
  ];

  useEffect(() => {
    axiosInstance
      .get(ARTIST_GETALL_URL)
      .then((response) => {
        setData(response.data);
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error fetching data: ", error);
        setLoading(false);
      });
  }, []);

  return (
    <Box m="20px">
      {/* HEADER */}
      <Box mb="5px">
        <Header title="Artists" subtitle="The list of artists!" />
        <Button
          variant="contained"
          sx={{
            width: "100%", // This makes the button span the full width
            backgroundColor: colors.blueAccent[500],
            "&:hover": {
              backgroundColor: darken(colors.blueAccent[600], 0.15),
            },
          }}
          onClick={handleAddArtist}
        >
          {" "}
          <Typography
            variant="h6"
            sx={{
              color:
                theme.palette.mode === "dark"
                  ? theme.palette.primary.contrastText
                  : theme.palette.secondary.contrastText,
              fontWeight: "bold",
            }}
          >
            Add New Artist
          </Typography>
        </Button>
      </Box>
      <Box
        m="0 0 0 0"
        height="520px"
        sx={{
          "& .MuiDataGrid-root": {},
          "& .MuiDataGrid-cell": {
            fontSize: "0.9rem",
            borderRight: "2px solid rgba(0, 0, 0, 0.1)",
          },
          "& .MuiDataGrid-columnHeaders": {
            backgroundColor: colors.blueAccent[700],
            fontSize: "1rem",
          },
          "& .MuiDataGrid-columnHeader": {
            borderRight: "2px solid #003366",
          },
          "& .MuiDataGrid-columnHeaderTitle": {
            fontWeight: "bold",
          },
          "& .MuiDataGrid-virtualScroller": {
            backgroundColor: colors.primary[400],
          },
          "& .MuiDataGrid-footerContainer": {
            backgroundColor: colors.blueAccent[700],
          },
          "& .MuiDataGrid-toolbarContainer": {
            "& .MuiButton-root, & .MuiIconButton-root, & .MuiTypography-root": {
              color: colors.grey[100],
            },
          },
        }}
      >
        <DataGrid
          loading={loading}
          slots={{
            toolbar: GridToolbar,
            loadingOverlay: LinearProgress,
          }}
          slotProps={{
            toolbar: {
              showQuickFilter: true,
              quickFilterProps: { debounceMs: 500 },
            },
          }}
          rows={data}
          columns={columns}
          initialState={{
            pagination: {
              paginationModel: { pageSize: 10, page: 0 },
            },
          }}
          pageSizeOptions={[5, 10, 25, 100]}
        />
      </Box>
      <DeleteModal
        isOpen={deleteModalOpen}
        onClose={handleCloseDeleteModal}
        onDelete={handleDeleteArtist}
      />
    </Box>
  );
}

export default Artists;
