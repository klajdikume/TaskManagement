# Stage 1: Build Angular application
FROM node:14 as builder

WORKDIR /app

COPY tm-client/package*.json ./

RUN npm install

COPY . .

RUN npm run build

# Stage 2: Install NGINX and serve the Angular application
FROM nginx:latest

# Remove default NGINX configuration
RUN rm /etc/nginx/conf.d/default.conf

# Copy your custom NGINX configuration to the container
COPY tm-client/nginx/default.conf /etc/nginx/conf.d/default.conf

# Copy the built Angular app from the builder stage to the NGINX web root directory
COPY --from=builder /app/dist/tm-client /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
