import * as yup from "yup";

// Artists Schemas
export const ArtistCreateSchema = yup.object().shape({
  artistName: yup
    .string()
    .required("Artist name is required")
    .max(256, "Artist name cannot exceed 256 characters"),
  projectIds: yup.array().min(1, "At least one project is required"),
});

export const ArtistUpdateSchema = yup.object().shape({
  artistName: yup
    .string()
    .required("Artist name is required")
    .max(256, "Artist name cannot exceed 256 characters"),
  projectIdsToAdd: yup.array(),
  projectIdsToRemove: yup.array(),
});

// Events Schemas
export const EventCreateSchema = yup.object().shape({
  title: yup
    .string()
    // .required("Title is required")
    .max(100, "Title must be between 1 and 100 characters"),
  description: yup
    .string()
    // .required("Description is required")
    .max(500, "Description must be between 1 and 500 characters"),
  eventDate: yup.date().notRequired(),
  eventDuration: yup
    .number()
    .notRequired()
    .integer()
    .min(1, "Event Duration must be at least 1 second")
    .max(86400, "Event Duration cannot exceed 86400 seconds"),
  liveStreamUrl: yup
    .string()
    .url("Live Stream URL must be a valid URL")
    .nullable(),
  location: yup
    .string()
    .max(200, "Location must be between 0 and 200 characters")
    .nullable(),
  status: yup
    .string()
    .oneOf(
      [
        "Draft",
        "Scheduled",
        "Confirmed",
        "Ongoing",
        "Completed",
        "Cancelled",
        "Postponed",
        "Rescheduled",
        "SoldOut",
        "Archived",
      ],
      "Invalid Event Status"
    )
    .nullable(),
  musicalProjectIds: yup.array().nullable(),
  generateTickets: yup.boolean(),
  numberOfTickets: yup.number().notRequired(),
  ticketPrice: yup.number().notRequired(),
  ticketType: yup
    .string()
    .oneOf(["Regular", "VIP"], "Invalid Ticket Type")
    .nullable(),
});

// Account Schemas
export const SignUpSchema = yup.object().shape({
  firstname: yup
    .string()
    .required("Firstname is required")
    .max(100, "Firstname cannot be more than 100 characters"),

  lastname: yup
    .string()
    .required("Lastname is required")
    .max(100, "Lastname cannot be more than 100 characters"),

  userName: yup
    .string()
    .required("Username is required")
    .max(100, "Username cannot be more than 100 characters"),

  phoneNumber: yup.string().required("PhoneNumber is required"),

  email: yup
    .string()
    .required("Email is required")
    .email("Invalid Email Address"),

  password: yup
    .string()
    .required("Password is required")
    .min(8, "Password must be at least 8 characters")
    .max(20, "Password cannot exceed 20 characters"),

  confirmPassword: yup.string().required("Confirm Password is required"),
});

export const SignInSchema = yup.object().shape({
  usernameOrEmail: yup
    .string()
    .required("Username or Email is required")
    .max(100, "Username or Email cannot be more than 100 characters"),

  password: yup
    .string()
    .required("Password is required")
    .min(8, "Password must be at least 8 characters long")
    .max(20, "Password cannot be more than 20 characters long"),

  rememberMe: yup.boolean(),
});

export const VerifyAccountSchema = yup.object().shape({
  otp: yup
    .string()
    .required("Otp is required"),
});

export const ForgotPasswordSchema = yup.object().shape({
  email: yup
    .string()
    .required("Email is required")
    .email("Invalid Email Address"),
});

export const ResetPasswordSchema = yup.object().shape({
  newPassword: yup
    .string()
    .required("New password is required")
    .min(8, "Password must be at least 8 characters long")
    .max(20, "Password cannot exceed 20 characters"),
  
  confirmPassword: yup
    .string()
    .required("Confirm Password is required")
    .oneOf([yup.ref('newPassword'), null], 'Passwords must match'),
});