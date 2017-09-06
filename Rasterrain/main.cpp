#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include <vector>
#include <cmath>
#include <limits>

#include <stdlib.h>
#include <stdio.h>
#include <time.h>

#include "Filestream.h"

#include "Vect.h"
#include "Ray.h"
#include "Camera.h"
#include "Color.h"
#include "Source.h"
#include "Light.h"
#include "Object.h"
#include "Sphere.h"
#include "Plane.h"

using namespace std;

int winningObjectIndex(vector<double> object_intersections){
  // return the index of the winning intersection
  int index_of_minimum_value;

  //prevent unnecessary caculations
  if(object_intersections.size() == 0){
    return -1;
  }
  else if(object_intersections.size() == 1){
    if(object_intersections.at(0) > 0){
      return 0;
    }
    else{
      return -1;
    }
  }
  else{
    //more than one intersections
    double max = 0;
    for(int i = 0; i < object_intersections.size(); i++){
      if(max < object_intersections.at(i)){
        max = object_intersections.at(i);
      }
    }
    if(max > 0){
      for(int i = 0; i < object_intersections.size(); i++){
        if(object_intersections.at(i) > 0 && object_intersections.at(i) <= max){
          max = object_intersections.at(i);
          index_of_minimum_value = i;
        }
      }
      return index_of_minimum_value;
    }
    else{
      return -1;
    }
  }
}

Color getColorAt(Vect intersection_position, Vect intersecting_ray_direction, vector<Object*> scene_objects, int index_of_winning_object, vector<Source*> light_sources, double accuracy, double ambientlight){

  Color winning_object_color = scene_objects.at(index_of_winning_object) -> getColor();
  Vect winning_object_normal = scene_objects.at(index_of_winning_object) ->getNormalAt (intersection_position);

  Color final_color = winning_object_color.colorScalar(ambientlight);

  for(int light_index = 0; light_index < light_sources.size(); light_index++){
    Vect light_direction = light_sources.at(light_index)->getLightPosition().vectAdd(intersection_position.negative()).normalize();

    float cosine_angle = winning_object_normal.dotProduct(light_direction);

    if(cosine_angle > 0){
      //test fopr shadows
      bool shadowed = false;

      Vect disance_to_light = light_sources.at(light_index) -> getLightPosition().vectAdd(intersection_position.negative()).normalize();
      float distance_to_light_magnitude = disance_to_light.magnitude(); //zinloos

      Ray shadow_ray (intersection_position, light_sources.at(light_index) -> getLightPosition().vectAdd(intersection_position.negative()).normalize());

      vector<double> secondary_intersections;

      for(int object_index = 0; object_index < scene_objects.size() && shadowed == false; object_index++){
        secondary_intersections.push_back(scene_objects.at(object_index) -> findIntersection(shadow_ray));
      }

      for(int c = 0; c < secondary_intersections.size(); c++){
        if(secondary_intersections.at(c) > accuracy){
          if(secondary_intersections.at(c) <= distance_to_light_magnitude){
            shadowed = true;
          }
          break;
        }
      }

      if(shadowed == false){
        final_color = final_color.colorAdd(winning_object_color.colorMultiply(light_sources.at(light_index) -> getLightColor()).colorScalar(cosine_angle));

        if(winning_object_color.getColorSpecial() > 0 && winning_object_color.getColorSpecial() <= 1){
          double dot1 = winning_object_normal.dotProduct(intersecting_ray_direction.negative());
          Vect scalar1 = winning_object_normal.vectMult(dot1);
          Vect add1 = scalar1.vectAdd(intersecting_ray_direction);
          Vect scalar2 = add1.vectMult(2);
          Vect add2 = intersecting_ray_direction.negative().vectAdd(scalar2);
          Vect reflection_direction = add2.normalize();

          double specular = reflection_direction.dotProduct(light_direction);
          if(specular > 0){
            specular = pow(specular, 10);
            final_color = final_color.colorAdd(light_sources.at(light_index) -> getLightColor().colorScalar(specular * winning_object_color.getColorSpecial()));

          }
        }
      }
    }
  }

  return final_color.clip();
}

int thisone;

int main(int argc, char *argv[]) {
  cout << "rendering ..." << endl;

  int dpi = 72;
  int width = 640;
  int height = 480;
  int n = width*height;
  RGBType *pixels = new RGBType[n];

  double aspectratio = (double) width / (double) height;
  double ambientlight = 0.2;
  double accuracy = 0.000001;

  Vect O (0, 0, 0);
  Vect X (1, 0, 0);
  Vect Y (0, 1, 0);
  Vect Z (0, 0, 1);

  Vect campos (3, 1.5, -4);
  Vect look_at(0, 0, 0);
  Vect diff_btw(campos.getVectX() - look_at.getVectX(), campos.getVectY() - look_at.getVectY(), campos.getVectZ() - look_at.getVectZ());

  Vect camdir = diff_btw.negative().normalize();
  Vect camright = Y.crossProduct(camdir).normalize();
  Vect camdown = camright.crossProduct(camdir);
  Camera scene_cam(campos, camdir, camright, camdown);

  Color white_light(1.0, 1.0, 1.0, 0);
  Color pretty_green(0.5, 1.0, 0.5, 0.3);
  Color maroon(0.5, 0.25, 0.25, 0);
  Color gray(0.5, 0.5, 0.5, 0);
  Color black(0.0, 0.0, 0.0, 0);

  Vect light_position (-7, 10, -10);
  Light scene_light(light_position, white_light);
  vector<Source*> light_sources;
  light_sources.push_back(dynamic_cast<Source*>(&scene_light)); //voeg alle ligthsources toe

  // scene objects
  Sphere scene_sphere(O, 1, pretty_green);
  Plane scene_plane(Y, -1, maroon);

  vector<Object*> scene_objects;
  scene_objects.push_back(dynamic_cast<Object*>(&scene_sphere));//klopt hier iets van?
  scene_objects.push_back(dynamic_cast<Object*>(&scene_plane));

  double xamnt, yamnt;

  for (int x = 0; x < width; x++){
    for(int y = 0; y < height; y++){
        thisone = y*width + x;

        //start without anti-aliasing
        if(width > height){ //Dit if statement snap ik nog niet helemaal
          xamnt = ((x + 0.5) / width) * aspectratio - (((width - height) / (double) height) / 2);
          yamnt = ((height - y) + 0.5) / height;
        }
        else if(height > width){
          xamnt = (x + 0.5) / width;
          yamnt = (((height - y) + 0.5) /height) / aspectratio - (((height - width) / (double) width) / 2);
        }
        else{
          xamnt = (x + 0.5) / width;
          yamnt = ((height - y) + 0.5) / height;
        }

        Vect cam_ray_origin = scene_cam.getCameraPosition();
        Vect cam_ray_direction = camdir.vectAdd(camright.vectMult(xamnt - 0.5).vectAdd(camdown.vectMult(yamnt -0.5))).normalize();

        Ray cam_ray(cam_ray_origin, cam_ray_direction);

        vector<double> intersections;

        for(int i = 0; i < scene_objects.size(); i++){
          intersections.push_back(scene_objects.at(i) -> findIntersection(cam_ray));
        }

        int index_of_winning_object = winningObjectIndex(intersections);

        if(index_of_winning_object == -1){
          //background
          pixels[thisone].r = 0;
          pixels[thisone].g = 0;
          pixels[thisone].b = 0;
        }else{
          if(intersections.at(index_of_winning_object) > accuracy){

            Vect intersection_position = cam_ray_origin.vectAdd(cam_ray_direction.vectMult(intersections.at(index_of_winning_object)));
            Vect intersecting_ray_direction = cam_ray_direction;

            Color intersection_color = getColorAt(intersection_position, intersecting_ray_direction, scene_objects, index_of_winning_object, light_sources, accuracy, ambientlight);

            pixels[thisone].r = intersection_color.getColorRed();
            pixels[thisone].g = intersection_color.getColorGreen();
            pixels[thisone].b = intersection_color.getColorBlue();
          }
        }

    }
  }

  Filestream::savembp("scene.bmp",width,height,dpi,pixels);
  cout << "done!" << endl;
  return 0;
}
